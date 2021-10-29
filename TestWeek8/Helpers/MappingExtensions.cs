using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeek8.Core.Models;
using TestWeek8.Models;

namespace TestWeek8.Helpers
{
    public static class MappingExtensions
    {
        public static MenuViewModel ToViewModel(this Menu menu)
        {
            return new MenuViewModel
            {
                Id = menu.Id,
                Name=menu.Name
            };
        }

        public static IEnumerable<MenuViewModel> ToListViewModel(this IEnumerable<Menu> menus)
        {
            return menus.Select(e => e.ToViewModel());
        }

        public static Menu ToMenu (this MenuViewModel menuViewModel)
        {
            return new Menu
            {
                Id = menuViewModel.Id,
                Name = menuViewModel.Name
            };
        }
    }
}
