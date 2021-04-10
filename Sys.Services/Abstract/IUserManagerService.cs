using Sys.Model.Database.Usuarios;
using Sys.Model.Services.User;
using System.Threading.Tasks;

namespace Sys.Services.Abstract
{
    public interface IUserManagerService
    {
        Task<Model.Database.Usuarios.User> RegisterUser(CreateUserRequest model);

        Task<UserInfo> UserAuthenticate(UserRequest userRequest);

        Task<UserInfo> GetUser(UserRequest userRequest);

        Task<UserRequest> PasswordUpdate(UserRequest userRequest);
    }
}