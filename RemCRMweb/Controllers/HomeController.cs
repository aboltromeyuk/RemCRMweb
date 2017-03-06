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
    public class HomeController : Controller
    {
        MenuService menuService = new MenuService();
        ApplicationContext context = new ApplicationContext();

        [Authorize]
        // GET: Home
        public ActionResult Index()
        {
            //using (menuService.Context = context)
            //{
            //    menuService.AddMenu("General");
            //    var listItem = new List<ItemViewModel>();
            //    listItem.Add(new ItemViewModel { Name = "Заказы", Url = "Orders" });
            //    listItem.Add(new ItemViewModel { Name = "Кассы", Url = "Cashboxs" });
            //    listItem.Add(new ItemViewModel { Name = "Настройки", Url = "Settings" });

            //    foreach (var item in listItem)
            //        menuService.AddItemToMenu(menuService.GetMenu("General").Id, new ItemViewModel { Name = item.Name, Url = item.Url });
            //}

            return View();
        }
    }
}