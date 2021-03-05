using System;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Sys.Services.Authentication
{
    public class GenerateToken : Abstract.IGenerateToken
    {
        Database.Repository.Application.IApplicationRepository _applicationRepository;
        public GenerateToken(
            Database.Repository.Application.IApplicationRepository applicationRepository
            )
        {
            _applicationRepository = applicationRepository;
        }

        public Model.Authentication.Token CreateToken(Model.Authentication.RequestToken requestToken)
        {
            Model.Authentication.Token tokenModel = new Model.Authentication.Token();
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();

            try
            {
                Database.Model.Application.Application application = new Database.Model.Application.Application();

                var model = _applicationRepository.ClientVerify(requestToken.ClientId, requestToken.Secret, requestToken.ClientScope, requestToken.ClientGrantType);

                if (!model.Result.Success)
                    throw new Exception($"Cliente não encontrado. Erro: {model.Result.ResultMessage}");

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(model.Secret.SecretValue);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, model.Client.UniqueKey)
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                foreach (var item in model.Scope)
                {
                    claimsIdentity = new ClaimsIdentity(
                                        new Claim[]
                                            {
                                                new Claim(ClaimTypes.Role, item.Name)
                                            });
                }

                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, model.Client.UniqueKey));

                tokenDescriptor.Subject = claimsIdentity;

                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

                tokenModel.Success = true;
                tokenModel.Message = "Token gerado com sucesso";
                tokenModel.TokenAccess = tokenHandler.WriteToken(token).ToString();
                tokenModel.DateValidade = tokenDescriptor.Expires;
            }
            catch (Exception ex)
            {
                tokenModel.Success = false;
                tokenModel.Message = ex.Message;
            }

            return tokenModel;
        }
    }
}
