using Sys.Database.Repository.Scheme.Usuarios.Credencials;
using Sys.Database.Repository.Scheme.Usuarios.Users;
using Sys.Model.Services.Common;
using Sys.Model.Services.User;
using System;
using System.Collections.Generic;
using System.Text;

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

        public Model.Database.Usuarios.User RegisterUser(UserRequest model)
        {
            Model.Database.Usuarios.User user = new Model.Database.Usuarios.User()
            {
                CPF = model.CPF,
                Gen = model.Gen,
                Name = model.Name,
                DataBirth = model.DataBirth,
                DataRegister = System.DateTime.Now,
                UniqueKey = new Guid()
            };

            if (string.IsNullOrEmpty(_usersRepository.ListByCPF(user).Name))
                user = _usersRepository.Insert(user);
            else
                throw new Exception("Usuário ja existe na base de dados");

            if (model.Login == "")
            {
                var list = model.Login.Split(" ");
                string firstName = "";
                string lastName = "";

                for (int i = 0; i < list.Length; i++)
                {
                    if (i == 0)
                        firstName = list[i];

                    if (i == (list.Length - 1))
                        lastName = list[i];
                }

                model.Login = $"{firstName}.{lastName}";
            }

            Model.Database.Usuarios.Credencials credencials = new Model.Database.Usuarios.Credencials()
            {
                UserId = Convert.ToInt32(user.Id),
                DataRegister = System.DateTime.Now,
                Login = model.Login,
                PassWord = _cryptographyService.StringEncript(model.PassWord)
            };

            if (string.IsNullOrEmpty(_credencialsRepository.ListByLogin(credencials).Login))
                credencials = _credencialsRepository.Insert(credencials);
            else
                throw new Exception("Login solicitado já está em uso.");

            return user;
        }

    }
}
