using Sys.Database.Repository.Scheme.Usuarios.Credencials;
using Sys.Database.Repository.Scheme.Usuarios.Users;
using Sys.Model.Services.User;
using System;
using System.Threading.Tasks;

namespace Sys.Services.Action
{
    public class UserManagerService : Abstract.IUserManagerService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ICredencialsRepository _credencialsRepository;
        private readonly Abstract.ICryptographyService _cryptographyService;

        public UserManagerService(
                IUsersRepository usersRepository,
                ICredencialsRepository credencialsRepository,
                Abstract.ICryptographyService cryptographyService
            )
        {
            _usersRepository = usersRepository;
            _credencialsRepository = credencialsRepository;
            _cryptographyService = cryptographyService;
        }

        public Task<Model.Database.Usuarios.User> RegisterUser(CreateUserRequest model)
        {
            Model.Database.Usuarios.User user = new Model.Database.Usuarios.User()
            {
                CPF = model.CPF,
                Gen = model.Gen,
                Name = model.Name,
                DataBirth = model.DataBirth,
                DataRegister = System.DateTime.Now,
                UniqueKey = Guid.NewGuid().ToString()
            };

            if (_usersRepository.ListByCPF(user) == null)
                user = _usersRepository.Insert(user);
            else
                throw new Exception("Usuário ja existe na base de dados");

            if (model.Login == "")
            {
                var list = model.Name.Split(" ");
                string firstName = "";
                string lastName = "";

                for (int i = 0; i < list.Length; i++)
                {
                    if (i == 0)
                        firstName = list[i];

                    if (i == (list.Length - 1))
                        lastName = list[i];
                }

                model.Login = $"{firstName}.{lastName}".ToLower();
            }

            Model.Database.Usuarios.Credencials credencials = new Model.Database.Usuarios.Credencials()
            {
                UserId = Convert.ToInt32(user.Id),
                DataRegister = System.DateTime.Now,
                Login = model.Login,
                PassWord = _cryptographyService.StringEncript(model.PassWord)
            };

            if (_credencialsRepository.ListByLogin(credencials) == null)
                credencials = _credencialsRepository.Insert(credencials);
            else
                throw new Exception("Login solicitado já está em uso.");

            return Task.FromResult(user);
        }

        public Task<UserInfo> UserAuthenticate(UserRequest userRequest)
        {
            var credencials = _credencialsRepository.ListByLogin(
                    new Model.Database.Usuarios.Credencials()
                    {
                        Login = userRequest.Login
                    }
                );
            if (credencials == null)
                throw new Exception($"Login não encontrado");

            if(userRequest.Password != _cryptographyService.StringDecript(credencials.PassWord))
                throw new Exception($"Senha Incorreta");

            var user = _usersRepository.ListById(
                    new Model.Database.Usuarios.User() 
                    { 
                        Id = credencials.UserId
                    }
                );

            UserInfo userInfo = new UserInfo()
            {
                Id = user.Id,
                CPF = user.CPF,
                DataBirth = user.DataBirth,
                DataRegister = user.DataRegister,
                Gen = user.Gen,
                Login = credencials.Login,
                PassWord = credencials.PassWord,
                Name = user.Name,
                UniqueKey = user.UniqueKey
            };

            return Task.FromResult(userInfo);
        }

        public Task<UserInfo> GetUser(UserRequest userRequest)
        {
            var credencials = _credencialsRepository.ListByLogin(
                    new Model.Database.Usuarios.Credencials()
                    {
                        Login = userRequest.Login
                    }
                );
            if (credencials == null)
                throw new Exception($"Login não encontrado");

            var user = _usersRepository.ListById(
                   new Model.Database.Usuarios.User()
                   {
                       Id = credencials.UserId
                   }
               );

            UserInfo userInfo = new UserInfo()
            {
                Id = user.Id,
                CPF = user.CPF,
                DataBirth = user.DataBirth,
                DataRegister = user.DataRegister,
                Gen = user.Gen,
                Login = credencials.Login,
                PassWord = credencials.PassWord,
                Name = user.Name,
                UniqueKey = user.UniqueKey
            };

            return Task.FromResult(userInfo);
        }

        public Task<UserRequest> PasswordUpdate(UserRequest userRequest)
        {
            var credencials = _credencialsRepository.ListByLogin(
                   new Model.Database.Usuarios.Credencials()
                   {
                       Login = userRequest.Login
                   }
               );

            credencials.PassWord = _cryptographyService.StringEncript(userRequest.Password);

            _credencialsRepository.Update(credencials);

            userRequest.Password = credencials.PassWord;

            return Task.FromResult(userRequest);
        }
    }
}
