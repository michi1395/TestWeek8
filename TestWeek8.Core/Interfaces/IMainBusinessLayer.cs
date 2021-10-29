using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek8.Core.Models;

namespace TestWeek8.Core.Interfaces
{
    public interface IMainBusinessLayer
    {
        #region MENU
        IEnumerable<Menu> FetchMenus(Func<Menu, bool> filter = null);
        Menu GetMenuById(int id);
        Menu GetMenuByName(string name);
        ResultBL CreateMenu(Menu newMenu);
        ResultBL DeleteMenu(int menuId);
        #endregion

        #region USER

        User GetUserByEmail(string email);

        #endregion
    }
}
