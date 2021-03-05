using Sys.Database.Model.DataBase;
using Sys.Database.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Database.Repository.Application
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DataBase.Client.IClientRepository _clientRepository;
        private readonly DataBase.Secret.ISecretRepository _secretRepository;
        private readonly DataBase.Scope.IScopeRepository _scopeRepository;
        private readonly DataBase.GrantType.IGrantTypeRepository _grantTypeRepository;
        private readonly DataBase.ClitScopes.IClitScopesRepository _clitScopesRepository;
        private readonly DataBase.ClitGranType.IClitGranTypeRepository _clitGranTypeRepository;

        public ApplicationRepository(
            DataBase.Client.IClientRepository clientRepository,
            DataBase.Secret.ISecretRepository secretRepository,
            DataBase.Scope.IScopeRepository scopeRepository,
            DataBase.GrantType.IGrantTypeRepository grantTypeRepository,
            DataBase.ClitScopes.IClitScopesRepository clitScopesRepository,
            DataBase.ClitGranType.IClitGranTypeRepository clitGranTypeRepository
            )
        {
            _clientRepository = clientRepository;
            _secretRepository = secretRepository;
            _scopeRepository = scopeRepository;
            _grantTypeRepository = grantTypeRepository;
            _clitScopesRepository = clitScopesRepository;
            _clitGranTypeRepository = clitGranTypeRepository;
        }

        public Model.DataBase.Client CreateApplication(Model.DataBase.Client client)
        {
            var listApplications = _clientRepository.List();

            if (!listApplications.Exists(app => app.Name == client.Name))
                client = _clientRepository.Insert(client);
            else
                client = listApplications.Find(app => app.Name == client.Name);

            return client;
        }

        public Model.DataBase.Secret CreateSecret(Model.DataBase.Secret secret)
        {
            var listSecret = _secretRepository.List();

            if (!listSecret.Exists(sct => sct.SecretValue == secret.SecretValue))
                secret = _secretRepository.Insert(secret);
            else
                secret = listSecret.Find(sct => sct.SecretValue == secret.SecretValue);

            return secret;
        }

        public List<Model.DataBase.GrantType> CreateGrantType(Model.DataBase.GrantType grantType)
        {
            if (!_grantTypeRepository.List().Exists(grt => grt.Type == grantType.Type))
                _grantTypeRepository.Insert(grantType);

            return _grantTypeRepository.List();
        }

        public List<Model.DataBase.Scope> CreateScopes(Model.DataBase.Scope scope)
        {
            if (!_scopeRepository.List().Exists(scp => scp.Name == scope.Name))
                _scopeRepository.Insert(scope);

            return _scopeRepository.List();
        }

        public void ConfigClientScop(ClitScopes clitScopes)
        {
            if (_clitScopesRepository.ListById(clitScopes) == null)
                _clitScopesRepository.Insert(clitScopes);
        }

        public void ConfigClientGrantType(ClitGrantType clitGrantType)
        {
            if (_clitGranTypeRepository.ListById(clitGrantType) == null)
                _clitGranTypeRepository.Insert(clitGrantType);
        }

        public Model.Application.Application ClientVerify(string UniqueKey, string SecretValue, List<string> Scopes, string grantType)
        {
            Model.Application.Application application = new Model.Application.Application();
            try
            {
                //Configura modelo para fazer verificação
                application = new Database.Model.Application.Application()
                {
                    Client = new Database.Model.DataBase.Client()
                    {
                        UniqueKey = UniqueKey
                    },
                    Secret = new Database.Model.DataBase.Secret()
                    {
                        FK_UniqueKeyApp = UniqueKey
                    },
                    ListGrantType = new Database.Model.DataBase.ClitGrantType()
                    {
                        ClientId = UniqueKey
                    },
                    ListScope = new List<Database.Model.DataBase.ClitScopes>(),
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

                application.Result = new Model.Application.Result()
                {
                    Success = true,
                    ResultMessage = "Client encontrado com sucesso"
                };   
            }
            catch (Exception ex)
            {
                string MessageBase = "Ocorreu um erro durante a operação, Descrição: ";
                application.Result = new Model.Application.Result()
                {
                    Success = false,
                    ResultMessage = $"{MessageBase}{ex.Message}"
                };
            }

            return application;
        }
    }
}

