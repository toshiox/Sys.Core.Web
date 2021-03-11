using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public Task<Database.Model.Application.Application> CreateApplication(Sys.Model.Application.Application application)
        {
            Database.Model.Application.Application modelApplication = new Database.Model.Application.Application();

            try
            {
                #region Criar Aplicacao
                modelApplication.Client = new Database.Model.DataBase.Client()
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
                modelApplication.Secret = new Database.Model.DataBase.Secret()
                {
                    DataRegister = DateTime.Now,
                    SecretValue = application.SecretValue,
                    FK_UniqueKeyApp = modelApplication.Client.UniqueKey
                };

                modelApplication.Secret = _applicationRepository.CreateSecret(modelApplication.Secret);
                #endregion

                #region Criar Escopos
                List<Database.Model.DataBase.Scope> listScopeResult = new List<Database.Model.DataBase.Scope>();

                foreach (var item in application.Scopes)
                {
                    var model = new Database.Model.DataBase.Scope()
                    {
                        Name = item.ScopeName,
                        Description = item.Description,
                        DataRegister = System.DateTime.Now
                    };

                    listScopeResult = _applicationRepository.CreateScopes(model);
                }
                #endregion

                #region Configurar Escopos da Aplicação
                modelApplication.Scope = new List<Database.Model.DataBase.Scope>();

                foreach (var item in listScopeResult)
                {
                    if (application.Scopes.Exists(ap => ap.ScopeName == item.Name))
                    {
                        _applicationRepository.ConfigClientScop(
                            new Database.Model.DataBase.ClitScopes
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
                List<Database.Model.DataBase.ClitGrantType> listClitGrantTypeCreate = new List<Database.Model.DataBase.ClitGrantType>();

                listClitGrantTypeCreate.Add(
                        new Database.Model.DataBase.ClitGrantType()
                        {
                            ClientId = modelApplication.Client.UniqueKey,
                            DataRegister = System.DateTime.Now,
                            GrantTypeId = _applicationRepository.GetGrantType(new Database.Model.DataBase.GrantType()
                            {
                                Type = application.GrantType
                            }).Id
                        });

                foreach (var item in listClitGrantTypeCreate)
                {
                    _applicationRepository.ConfigClientGrantType(item);
                }

                modelApplication.GrantType = _applicationRepository.GetGrantType(
                    new Database.Model.DataBase.GrantType()
                    {
                        Type = application.GrantType
                    });
                #endregion

                modelApplication.Result = new Database.Model.Application.Result()
                {
                    Success = true,
                    ResultMessage = "Aplicação Criada com Sucesso"
                };
            }
            catch (Exception ex)
            {
                modelApplication.Result = new Database.Model.Application.Result()
                {
                    Success = true,
                    ResultMessage = $"Ocorreu um Erro ao criar aplicação, Erro: {ex.Message}"
                };
            }
            return Task.FromResult(modelApplication);
        }
    }
}
