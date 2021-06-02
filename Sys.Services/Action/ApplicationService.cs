using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sys.Model.Database.Aplicativos;

namespace Sys.Services.Action
{
    public class ApplicationService : Abstract.IApplicationService
    {
        private readonly Database.Repository.Application.IApplicationRepository _applicationRepository;

        public ApplicationService(
                Database.Repository.Application.IApplicationRepository applicationRepository
            )
        {
            _applicationRepository = applicationRepository;
        }

        public Task<Database.Model.Application.ApplicationRepository> CreateApplication(Sys.Model.Services.Application.Application application)
        {
            Database.Model.Application.ApplicationRepository modelApplication = new Database.Model.Application.ApplicationRepository();

            #region Criar Aplicacao
            modelApplication.Client = new Client()
            {
                Active = true,
                DateRegister = DateTime.Now,
                Name = application.Name,
                Descrition = application.Descrition,
                UniqueKey = Guid.NewGuid().ToString(),
            };

            modelApplication.Client = _applicationRepository.CreateApplication(modelApplication.Client);

            modelApplication.UniqueKey = modelApplication.Client.UniqueKey;
            #endregion

            #region Criar Segredo da Aplicação
            modelApplication.Secret = new Secret()
            {
                DataRegister = DateTime.Now,
                SecretValue = application.SecretValue,
                FK_UniqueKeyApp = modelApplication.Client.UniqueKey
            };

            modelApplication.Secret = _applicationRepository.CreateSecret(modelApplication.Secret);
            #endregion

            #region Criar Escopos
            List<Scope> listScopeResult = new List<Scope>();

            foreach (var item in application.Scopes)
            {
                var model = new Scope()
                {
                    Name = item.ScopeName,
                    Description = item.Description,
                    DataRegister = System.DateTime.Now
                };

                listScopeResult = _applicationRepository.CreateScopes(model);
            }
            #endregion

            #region Configurar Escopos da Aplicação
            modelApplication.Scope = new List<Scope>();

            foreach (var item in listScopeResult)
            {
                if (application.Scopes.Exists(ap => ap.ScopeName == item.Name))
                {
                    _applicationRepository.ConfigClientScop(
                        new ClitScopes
                        {
                            DataRegister = System.DateTime.Now,
                            ClientId = modelApplication.Client.UniqueKey,
                            ScopeId = listScopeResult.Find(scope => scope.Name == item.Name).Id
                        });

                    modelApplication.Scope.Add(item);
                }
            }

            #endregion

            #region Configurar GrantType da Aplicação
            List<ClitGrantType> listClitGrantTypeCreate = new List<ClitGrantType>();

            listClitGrantTypeCreate.Add(
                    new ClitGrantType()
                    {
                        ClientId = modelApplication.Client.UniqueKey,
                        DataRegister = System.DateTime.Now,
                        GrantTypeId = _applicationRepository.GetGrantType(new GrantType()
                        {
                            Type = application.GrantType
                        }).Id
                    });

            foreach (var item in listClitGrantTypeCreate)
            {
                _applicationRepository.ConfigClientGrantType(item);
            }

            modelApplication.GrantType = _applicationRepository.GetGrantType(
                new GrantType()
                {
                    Type = application.GrantType
                });
            #endregion

            modelApplication.Success = true;
            modelApplication.ResultMessage = "Aplicação Criada com Sucesso";

            return Task.FromResult(modelApplication);
        }
    }
}
