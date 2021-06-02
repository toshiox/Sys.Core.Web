using System;
using System.Collections.Generic;
using System.Text;
using Sys.Database.Repository.Scheme.Usuarios.Acesso;
using Sys.Database.Repository.Scheme.Usuarios.Users;
using Sys.Database.Repository.Scheme.Front.Menu;
using Sys.Database.Repository.Scheme.Front.Group;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Sys.Services.Action
{
    public class PermissionControlService : Abstract.IPermissionControlService
    {
        private readonly IAcessRepository _acessRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly Abstract.ITokenManegerService _tokenManegerService;

        public PermissionControlService(
            IAcessRepository acessRepository,
            IMenuRepository menuRepository,
            IGroupRepository groupRepository,
            IUsersRepository usersRepository,
            Abstract.ITokenManegerService tokenManegerService
            )
        {
            _acessRepository = acessRepository;
            _menuRepository = menuRepository;
            _groupRepository = groupRepository;
            _usersRepository = usersRepository;
            _tokenManegerService = tokenManegerService;
        }

        public async Task<List<Sys.Model.Services.PermissionControl.MenuResponse>> GetMenu(HttpContext httpContext)
        {
            List<Sys.Model.Services.PermissionControl.MenuResponse> list = new List<Sys.Model.Services.PermissionControl.MenuResponse>();

            var User = _tokenManegerService.DecriptUserToken(httpContext).Result;

            var listAcess = _acessRepository.ListByUser(new Model.Database.Usuarios.Acesso()
            {
                UserId = User.Id
            });

            List<Model.Database.Front.Menu> listMenus = new List<Model.Database.Front.Menu>();
            foreach (var acess in listAcess)
                listMenus.Add(_menuRepository.ListById(new Model.Database.Front.Menu() { Id = acess.MenuId }));

            List<Model.Database.Front.Group> listGroup = new List<Model.Database.Front.Group>();
            foreach (var menu in listMenus)
            {
                var group = _groupRepository.ListById(new Model.Database.Front.Group() { Id = menu.GroupId });
                if (!listGroup.Exists(lst => lst.Name == group.Name))
                    listGroup.Add(group);
            }

            for (int i = 0; i < listGroup.Count; i++)
            {
                Sys.Model.Services.PermissionControl.MenuResponse item = new Model.Services.PermissionControl.MenuResponse()
                { 
                    menus = new List<Model.Database.Front.Menu>()
                };

                if (!list.Exists(lst => lst.Name == listGroup[i].Name))
                {
                    item.Name = listGroup[i].Name;
                    item.Icon = listGroup[i].Icon;

                    foreach (var menu in listMenus)
                    {
                        if (menu.GroupId == listGroup[i].Id)
                        {
                            menu.Route = $"/{listGroup[i].Route}/{menu.Route}";
                            item.menus.Add(menu);
                        }
                    }
                }

                list.Add(item);
            }


            return await Task.FromResult(list);
        }

    }

}
