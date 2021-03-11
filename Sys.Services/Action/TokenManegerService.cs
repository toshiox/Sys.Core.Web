using System;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Sys.Model.Authentication;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Sys.Services.Action
{
    public class TokenManegerService : Abstract.ITokenManegerService
    {
        Database.Repository.Application.IApplicationRepository _applicationRepository;
        public TokenManegerService(
            Database.Repository.Application.IApplicationRepository applicationRepository
            )
        {
            _applicationRepository = applicationRepository;
        }

        public Task<Token> CreateToken(RequestToken requestToken)
        {
            Token tokenModel = new Token();
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            Database.Model.Application.Application application = new Database.Model.Application.Application();
            try
            {
                var model = _applicationRepository.ClientVerify(requestToken.ClientId, requestToken.Secret, requestToken.ClientScope, requestToken.ClientGrantType);

                if (!model.Result.Success)
                    throw new Exception($"Cliente não encontrado. Erro: {model.Result.ResultMessage}");

                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Sys.Model.Struct.Authentication.Token.Key)),
                                SecurityAlgorithms.HmacSha256Signature
                            )
                };

                foreach (var item in model.Scope)
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, item.Name));
                }
                claimsIdentity.AddClaim(new Claim(ClaimTypes.SerialNumber, model.Secret.SecretValue));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, model.Client.UniqueKey));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.GivenName, model.GrantType.Type));

                tokenDescriptor.Subject = claimsIdentity;

                tokenHandler.CreateToken(tokenDescriptor);

                tokenModel.Success = true;
                tokenModel.Message = "Token gerado com sucesso";
                tokenModel.DateValidade = tokenDescriptor.Expires;
                tokenModel.TokenAccess = tokenHandler.WriteToken(
                        tokenHandler.CreateToken(tokenDescriptor)
                    ).ToString();
            }
            catch (Exception ex)
            {
                tokenModel.Success = false;
                tokenModel.Message = ex.Message;
            }
            return Task.FromResult(tokenModel);
        }

        public Task<RequestToken> ValidateToken(ValidateToken validateToken)
        {
            RequestToken requestToken = new RequestToken();
            requestToken.ClientScope = new List<string>();
            requestToken.Result = new Services.Model.Common.Result();

            try
            {
                var identity = validateToken.httpContext.User.Identity as ClaimsIdentity;

                foreach (var claim in identity.Claims)
                {
                    if (claim.Type.Contains("role"))
                        requestToken.ClientScope.Add(claim.Value);

                    if (claim.Type.Contains("serialnumber"))
                        requestToken.Secret = claim.Value;

                    if (claim.Type.Contains("nameidentifier"))
                        requestToken.ClientId = claim.Value;

                    if (claim.Type.Contains("givenname"))
                        requestToken.ClientGrantType = claim.Value;
                }

                var model = _applicationRepository.ClientVerify((validateToken.ClientId == "" ? requestToken.ClientId : validateToken.ClientId) , requestToken.Secret, requestToken.ClientScope, requestToken.ClientGrantType);
                if (!model.Result.Success)
                    throw new Exception($"Cliente não encontrado. Erro: {model.Result.ResultMessage}");

                requestToken.Result.Success = true;
                requestToken.Result.ResultMessage = "Token validado com sucesso.";
            }
            catch (Exception ex)
            {
                requestToken.Result.Success = false;
                requestToken.Result.ResultMessage = ex.Message;
            }

            return Task.FromResult(requestToken);
        }
    }
}
