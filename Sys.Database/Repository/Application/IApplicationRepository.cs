using System;
using System.Collections.Generic;
using System.Text;
using Sys.Model.Database.Aplicativos;

namespace Sys.Database.Repository.Application
{
    public interface IApplicationRepository
    {
        Client CreateApplication(Client client);

        Secret CreateSecret(Secret SecretValue);

        List<Scope> CreateScopes(Scope scope);

        List<GrantType> CreateGrantType(GrantType grantType);

        GrantType GetGrantType(GrantType grantType);

        void ConfigClientScop(ClitScopes clitScopes);

        void ConfigClientGrantType(ClitGrantType clitGrantType);

        Model.Application.ApplicationRepository ClientVerify(string UniqueKey, string SecretValue, List<string> Scopes, string grantType);
    }
}
