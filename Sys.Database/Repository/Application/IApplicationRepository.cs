using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Database.Repository.Application
{
    public interface IApplicationRepository
    {
        Model.DataBase.Client CreateApplication(Model.DataBase.Client client);

        Model.DataBase.Secret CreateSecret(Model.DataBase.Secret SecretValue);

        List<Model.DataBase.Scope> CreateScopes(Model.DataBase.Scope scope);

        List<Model.DataBase.GrantType> CreateGrantType(Model.DataBase.GrantType grantType);

        void ConfigClientScop(Model.DataBase.ClitScopes clitScopes);

        void ConfigClientGrantType(Model.DataBase.ClitGrantType clitGrantType);

        Model.Application.Application ClientVerify(string UniqueKey, string SecretValue, List<string> Scopes, string grantType);
    }
}
