using Sys.Model.Database.Usuarios;
using Sys.Model.Services.User;

namespace Sys.Services.Abstract
{
    public interface IUserManagerService
    {
        User RegisterUser(UserRequest model);
    }
}