using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeek8.Core.Interfaces;
using TestWeek8.Core.Models;
using TestWeek8.Helpers;
using TestWeek8.Models;

namespace TestWeek8.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMainBusinessLayer mainBl;

        public MenuController(IMainBusinessLayer bl)
        {
            this.mainBl = bl;
        }

        public IActionResult Index()
        {
            //recupero i dati
            var result = mainBl.FetchMenus();
            var resultMapping = result.ToListViewModel();
            return View(resultMapping);
        }

        //GET Menus/Detail/{name}
        //[LogFilterAttribute]
        public IActionResult Detail(string name)
        {
            if (string.IsNullOrEmpty(name))
                return View("NotFound");
            var menu = this.mainBl.GetMenuByName(name);
            if (menu == null)
                return View("NotFound");
            var resultMapped = menu.ToViewModel();
            return View(resultMapped);
        }

        //HTTP GET Menus/Create
        [Authorize(Policy = "AdministratorUser")]
        public IActionResult Create()
        {
            return View(new MenuViewModel());
        }

        //HTTP POST Menus/Create
        //[LogFilterAttribute]
        [HttpPost]
        public IActionResult Create(MenuViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model == null)
            {
                return View("ExceptionError", new ResultBL(false, "Error!"));
            }
            //Mappatura da Menu View Model a Menu
            Menu newMenu = model.ToMenu();
            var result = mainBl.CreateMenu(newMenu);
            if (!result.Success)
            {
                return View("ExceptionError", result);
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "AdministratorUser")]
        [Route("Menus/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return Json(false);
            //chiamata al BL
            var result = mainBl.DeleteMenu(id);
            return Json(result.Success);
        }
    }
}
