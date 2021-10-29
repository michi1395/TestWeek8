using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek8.Core.Interfaces;
using TestWeek8.Core.Models;

namespace TestWeek8.EF.Repository
{
    public class RepositoryMenuEF : IRepositoryMenu
    {
        private readonly MenuContext ctx;

        public RepositoryMenuEF(MenuContext context)
        {
            this.ctx = context;
        }

        public bool AddItem(Menu item)
        {
            if (item == null)
                return false;
            ctx.Menus.Add(item);
            ctx.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            if (id <= 0)
                return false;

            
            var menuToDelete = ctx.Menus.Find(id);
            if (menuToDelete == null)
                return false;
            ctx.Menus.Remove(menuToDelete);
            ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Menu> Fetch(Func<Menu, bool> filter = null)
        {
            if (filter != null)
                return this.ctx.Menus.Where(filter);
            return ctx.Menus;
        }

        public Menu GetById(int id)
        {
            if (id <= 0)
                return null;
            return ctx.Menus.Find(id);
        }

        public Menu GetMenuByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;
            return ctx.Menus.FirstOrDefault(e => e.Name.Equals(name));
        }
  
    }
}
