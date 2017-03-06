using RemCRMbl.Services;
using RemCRMdal.AplicationDAL;
using RemCRMviewModel.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemCRMweb.Controllers
{
    public class MenuController : Controller
    {
        ApplicationContext context = new ApplicationContext();
        MenuService menuService = new MenuService();
        // GET: Menu
        public ActionResult MenuApp()
        {
            var result = new MenuViewModel();

            using (menuService.Context = context)
            {
                result = menuService.GetMenu("General");
            }

            return View(result);
        }
    }
}