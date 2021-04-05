using System;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Sys.Model.Services.Authentication;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Sys.Model.Services.User;

namespace Sys.Services.Action
{
    public class TokenManegerService : Abstract.ITokenManegerService
    {
        Database.Repository.Application.IApplicationRepository _applicationRepository;
        Services.Abstract.IUserManagerService _userManagerService;

        private readonly Configuration.ApplicationConfiguration _configuration;

        public TokenManegerService(
            Database.Repository.Application.IApplicationRepository applicationRepository,
            Abstract.IUserManagerService userManagerService
            )
        {
            _applicationRepository = applicationRepository;
            _configuration = new Configuration.ApplicationConfiguration();
            _userManagerService = userManagerService;
        }

        public Task<Token> CreateServiceToken(RequestToken requestToken)
        {
            Token tokenModel = new Token();
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            Database.Model.Application.ApplicationRepository application = new Database.Model.Application.ApplicationRepository();

            var model = _applicationRepository.ClientVerify(requestToken.ClientId, requestToken.Secret, requestToken.ClientScope, requestToken.ClientGrantType);

            if (!model.Success)
                throw new Exception($"Cliente não encontrado. Erro: {model.ResultMessage}");

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Sys.Model.Services.Struct.Authentication.Token.Key)),
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


            tokenModel.DateValidade = tokenDescriptor.Expires;
            tokenModel.TokenAccess = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)).ToString();
            return Task.FromResult(tokenModel);
        }

        public Task<ValidateToken> ValidateServiceToken(HttpContext httpContext)
        {
            ValidateToken requestToken = new ValidateToken();
            requestToken.ClientScope = new List<string>();

            try
            {
                var identity = httpContext.User.Identity as ClaimsIdentity;

                foreach (var claim in identity.Claims)
                {
                    if (claim.Type.Contains("role"))
                        requestToken.ClientScope.Add(claim.Value);

                    if (claim.Type.Contains("serialnumber"))
                        requestToken.Secret = claim.Value;

                    if (claim.Type.Contains("nameidentifier"))
                        requestToken.ClientId = Guid.Parse(claim.Value);

                    if (claim.Type.Contains("givenname"))
                        requestToken.ClientGrantType = claim.Value;
                }

                if (_configuration.GetClientID(requestToken.ClientId))
                {
                    var model = _applicationRepository.ClientVerify(requestToken.ClientId.ToString(), requestToken.Secret, requestToken.ClientScope, requestToken.ClientGrantType);

                    if (!model.Success)
                        throw new Exception($"Cliente não encontrado. Erro: {model.ResultMessage}");
                }
                else
                    throw new Exception($"ClientID {requestToken.ClientId} incorreto");

                requestToken.Success = true;
                requestToken.ResultMessage = "Token validado com sucesso.";
            }
            catch (Exception ex)
            {
                requestToken.Success = false;
                requestToken.ResultMessage = ex.Message;
            }

            return Task.FromResult(requestToken);
        }

        public async Task<Token> CreateUserToken(UserRequest userRequest)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            Token token = new Token();

            var user = await _userManagerService.GetUser(userRequest);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                   new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Sys.Model.Services.Struct.Authentication.Token.Key)),
                           SecurityAlgorithms.HmacSha256Signature
                       )
            };
            
            claimsIdentity.AddClaim(new Claim(ClaimTypes.SerialNumber, user.PassWord));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UniqueKey));

            tokenDescriptor.Subject = claimsIdentity;
            tokenHandler.CreateToken(tokenDescriptor);

            token.DateValidade = tokenDescriptor.Expires;
            token.TokenAccess = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)).ToString();

            return token;
        }


    }
}
