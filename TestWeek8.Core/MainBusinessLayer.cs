
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek8.Core.Interfaces;
using TestWeek8.Core.Models;

namespace AcademyG.Week8.Core
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        private readonly IRepositoryMenu repoMenu;
        private readonly IRepositoryUser repoUser;

        public MainBusinessLayer(IRepositoryMenu repoMenu,
                                IRepositoryUser repoUser)
        {
            this.repoMenu = repoMenu;
            this.repoUser = repoUser;
        }


        public ResultBL CreateMenu(Menu newMenu)
        {
            if (newMenu == null)
                return new ResultBL(false, "Invalid Menu data");
            var result = repoMenu.AddItem(newMenu);

            return new ResultBL(result, result ? "Ok!" : "Sorry, something wrong!");
        }

        public ResultBL DeleteMenu(int menuId)
        {
            if (menuId <= 0)
                return new ResultBL(false, "Invalid ID");
            var result = repoMenu.DeleteItem(menuId);
            if (!result)
                return new ResultBL(result, "Something wrong");
            return new ResultBL(result, "Ok!");
        }


        public IEnumerable<Menu> FetchMenus(Func<Menu, bool> filter = null)
        {
            return this.repoMenu.Fetch(filter);
        }

        public Menu GetMenuByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            return this.repoMenu.GetMenuByName(name);
        }

        public Menu GetMenuById(int id)
        {
            if (id <= 0)
                return null;
            return this.repoMenu.GetById(id);
        }

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;
            return repoUser.GetByEmail(email);
        }
    }
}
