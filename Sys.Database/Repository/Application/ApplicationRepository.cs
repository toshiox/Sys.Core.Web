using Sys.Model.Services.Struct.Database;
using Sys.Model.Database.Aplicativos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Database.Repository.Application
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly Scheme.Aplicativos.Client.IClientRepository _clientRepository;
        private readonly Scheme.Aplicativos.Secret.ISecretRepository _secretRepository;
        private readonly Scheme.Aplicativos.Scope.IScopeRepository _scopeRepository;
        private readonly Scheme.Aplicativos.GrantType.IGrantTypeRepository _grantTypeRepository;
        private readonly Scheme.Aplicativos.ClitScopes.IClitScopesRepository _clitScopesRepository;
        private readonly Scheme.Aplicativos.ClitGranType.IClitGranTypeRepository _clitGranTypeRepository;

        public ApplicationRepository(
            Scheme.Aplicativos.Client.IClientRepository clientRepository,
            Scheme.Aplicativos.Secret.ISecretRepository secretRepository,
            Scheme.Aplicativos.Scope.IScopeRepository scopeRepository,
            Scheme.Aplicativos.GrantType.IGrantTypeRepository grantTypeRepository,
            Scheme.Aplicativos.ClitScopes.IClitScopesRepository clitScopesRepository,
            Scheme.Aplicativos.ClitGranType.IClitGranTypeRepository clitGranTypeRepository
            )
        {
            _clientRepository = clientRepository;
            _secretRepository = secretRepository;
            _scopeRepository = scopeRepository;
            _grantTypeRepository = grantTypeRepository;
            _clitScopesRepository = clitScopesRepository;
            _clitGranTypeRepository = clitGranTypeRepository;
        }

        public Client CreateApplication(Client client)
        {
            var listApplications = _clientRepository.List();

            if (!listApplications.Exists(app => app.Name == client.Name))
                client = _clientRepository.Insert(client);
            else
                client = listApplications.Find(app => app.Name == client.Name);

            return client;
        }

        public Secret CreateSecret(Secret secret)
        {
            var listSecret = _secretRepository.List();

            if (!listSecret.Exists(sct => sct.SecretValue == secret.SecretValue))
                secret = _secretRepository.Insert(secret);
            else
                secret = listSecret.Find(sct => sct.SecretValue == secret.SecretValue);

            return secret;
        }

        public List<GrantType> CreateGrantType(GrantType grantType)
        {
            if (!_grantTypeRepository.List().Exists(grt => grt.Type == grantType.Type))
                _grantTypeRepository.Insert(grantType);

            return _grantTypeRepository.List();
        }

        public GrantType GetGrantType(GrantType grantType)
        {
             return _grantTypeRepository.ListByName(grantType);
        }

        public List<Scope> CreateScopes(Scope scope)
        {
            if (!_scopeRepository.List().Exists(scp => scp.Name == scope.Name))
                _scopeRepository.Insert(scope);

            return _scopeRepository.List();
        }

        public void ConfigClientScop(ClitScopes clitScopes)
        {
            if (_clitScopesRepository.ListByScopeId(clitScopes).Count == 0)
                _clitScopesRepository.Insert(clitScopes);
        }

        public void ConfigClientGrantType(ClitGrantType clitGrantType)
        {
            if (_clitGranTypeRepository.ListById(clitGrantType) == null)
                _clitGranTypeRepository.Insert(clitGrantType);
        }

        public Model.Application.ApplicationRepository ClientVerify(string UniqueKey, string SecretValue, List<string> Scopes, string grantType)
        {
            Model.Application.ApplicationRepository application = new Model.Application.ApplicationRepository();
            try
            {
                //Configura modelo para fazer verificação
                application = new Database.Model.Application.ApplicationRepository()
                {
                    Client = new Client()
                    {
                        UniqueKey = UniqueKey
                    },
                    Secret = new Secret()
                    {
                        FK_UniqueKeyApp = UniqueKey
                    },
                    ListGrantType = new ClitGrantType()
                    {
                        ClientId = UniqueKey
                    },
                    ListScope = new List<ClitScopes>(),
                };

                application.Client = _clientRepository.ListByUniqueKey(application.Client);
                if (application.Client == null)
                    throw new Exception("UniqueKey não foi encontrada na base de dados.");

                application.Secret = _secretRepository.ListById(application.Secret);
                if (application.Secret.SecretValue != SecretValue || application.Secret == null)
                    throw new Exception("UniqueKey não foi vinculada a um Segredo solicitado na base de dados.");

                application.ListGrantType = _clitGranTypeRepository.ListById(application.ListGrantType);
                if (application.ListGrantType == null)
                    throw new Exception("UniqueKey não foi vinculada a um GrantType na base de dados.");

                application.ListScope = _clitScopesRepository.ListById(new ClitScopes()
                {
                    ClientId = UniqueKey
                });

                if(Scopes.Count != application.ListScope.Count)
                    throw new Exception("Não foram passados todos os escopos para acessar Client");

                //Usa o ID dos escopos para buscar as definições
                application.Scope = new List<Scope>();
                foreach (var item in application.ListScope)
                {
                    var scopeModel = new Scope()
                    {
                        Id = item.ScopeId,
                    };

                    application.Scope.Add(_scopeRepository.ListById(new Scope()
                    {
                        Id = item.ScopeId
                    }));
                }

                if (application.Scope == null)
                    throw new Exception("UniqueKey não foi vinculada a nenhum Escopo na base de dados.");

                foreach (var item in Scopes)
                {
                    if (!application.Scope.Exists(s => s.Name == item))
                        throw new Exception($"Escopo {item} não foi atribuido para o Client {application.Client.UniqueKey}");
                }

                application.GrantType = _grantTypeRepository.ListById(new GrantType()
                {
                    Id = application.ListGrantType.GrantTypeId
                });

                if(application.GrantType.Type != grantType)
                    throw new Exception($"Grant_Type {grantType} não foi atribuido para o Client {application.Client.UniqueKey}");

                application.Success = true;
                application.ResultMessage = "Client encontrado com sucesso";
            }
            catch (Exception ex)
            {
                application.Success = false;
                application.ResultMessage = $"Ocorreu um erro durante a operação, Descrição: {ex.Message}";
            }

            return application;
        }
    }
}

