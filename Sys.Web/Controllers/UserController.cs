using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Sys.Model.Services.User;
using Sys.Services.Abstract;

namespace Sys.Web.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : Services.Common.BaseController<CreateUserRequest>
    {
        private readonly IUserManagerService _userManagerService;
        private readonly IPermissionControlService _permissionControlService;

        public UserController(
             IUserManagerService userManagerService,
            Services.Abstract.ITokenManegerService tokenManegerService,
            ILogger<CreateUserRequest> logger,
            IPermissionControlService permissionControlService
            ) : base(logger, tokenManegerService)
        {
            _userManagerService = userManagerService;
            _permissionControlService = permissionControlService;
        }

        [HttpGet]
        [Route("teste")]
        public Model.Services.Common.Result teste()
        {
            return new Model.Services.Common.Result()
            {
                ResultMessage = "ola",
                Success = true,
                Data = new Model.Services.User.CreateUserRequest()
                {
                    CPF = "40011051876",
                    Name = "Gustavo Toshio"
                }
            };
        }

        [HttpPost]
        [Route("Register")]
        [SwaggerOperation("Cadastrar Novo Usuario", "Cadastra novo usuário para acessar o sistema", Tags = new string[1] { "User" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(CreateUserRequest))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(CreateUserRequest))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(UserRequest))]
        public async Task<Model.Services.Common.Result> RegisterUser([FromBody] CreateUserRequest model)
        {
            var Validate = _tokenManegerService.ValidateServiceToken(HttpContext).Result;

            if (Validate.Success)
            {
                try
                {
                    Model.Services.Common.Result result = new Model.Services.Common.Result();

                    result.Data = await _userManagerService.RegisterUser(model);
                    result.Success = true;
                    result.ResultMessage = "Usuario cadastrado com sucesso";

                    return result;
                }
                catch (Exception ex)
                {
                    return new Model.Services.Common.Result()
                    {
                        Success = false,
                        ResultMessage = $"Ocorreu um erro durante a operação, Descricao: {ex.Message}"
                    };
                }
            }
            else
            {
                return new Model.Services.Common.Result()
                {
                    Success = false,
                    ResultMessage = $"Token Inválido, Descricao: {Validate.ResultMessage}"
                };
            }
        }


        [HttpGet]
        [Route("UserInfo")]
        [SwaggerOperation("Resgatar Informações Usuário", "Resgatar informações do usuário na base de dados", Tags = new string[1] { "User" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(UserRequest))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(UserRequest))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(UserRequest))]
        public async Task<Model.Services.Common.Result> UserInfo([FromBody] UserRequest model)
        {
            var Validate = _tokenManegerService.ValidateServiceToken(HttpContext).Result;

            if (Validate.Success)
            {
                try
                {
                    Model.Services.Common.Result result = new Model.Services.Common.Result();

                    result.Data = await _userManagerService.GetUser(model);
                    result.Success = true;
                    result.ResultMessage = "Infomações Listadas com sucesso";

                    return result;
                }
                catch (Exception ex)
                {
                    return new Model.Services.Common.Result()
                    {
                        Success = false,
                        ResultMessage = $"Ocorreu um erro durante a operação, Descricao: {ex.Message}"
                    };
                }
            }
            else
            {
                return new Model.Services.Common.Result()
                {
                    Success = false,
                    ResultMessage = $"Token Inválido, Descricao: {Validate.ResultMessage}"
                };
            }
        }

        [HttpPost]
        [Route("UserUpdate")]
        [SwaggerOperation("Alterar Usuario", "Alterar informãções do usuário", Tags = new string[1] { "User" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(UserRequest))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(UserRequest))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(UserRequest))]
        public async Task<Model.Services.Common.Result> UpdateInfo([FromBody] UserRequest model)
        {
            var Validate = _tokenManegerService.ValidateServiceToken(HttpContext).Result;

            if (Validate.Success)
            {
                try
                {
                    Model.Services.Common.Result result = new Model.Services.Common.Result();

                    result.Data = await _userManagerService.PasswordUpdate(model);
                    result.Success = true;
                    result.ResultMessage = "Infomações Listadas com sucesso";

                    return result;
                }
                catch (Exception ex)
                {
                    return new Model.Services.Common.Result()
                    {
                        Success = false,
                        ResultMessage = $"Ocorreu um erro durante a operação, Descricao: {ex.Message}"
                    };
                }
            }
            else
            {
                return new Model.Services.Common.Result()
                {
                    Success = false,
                    ResultMessage = $"Token Inválido, Descricao: {Validate.ResultMessage}"
                };
            }
        }

        [HttpGet]
        [Route("UserPermission")]
        [SwaggerOperation("Listar Permissões", "Listar permissões usuários", Tags = new string[1] { "User" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(UserRequest))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(UserRequest))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(UserRequest))]
        public async Task<Model.Services.Common.Result> ListPermission()
        {
            try
            {
                Model.Services.Common.Result result = new Model.Services.Common.Result();

                result.Data = await _permissionControlService.GetMenu(HttpContext);
                result.Success = true;
                result.ResultMessage = "Infomações Listadas com sucesso";

                return result;
            }
            catch (Exception ex)
            {
                return new Model.Services.Common.Result()
                {
                    Success = false,
                    ResultMessage = $"Ocorreu um erro durante a operação, Descricao: {ex.Message}"
                };
            }
        }
        
    }
}
