using Newtonsoft.Json;
using RemCRMbl.Services;
using RemCRMdal.AplicationDAL;
using RemCRMviewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemCRMweb.Controllers
{
    public class AppController : Controller
    {
        ClientService clientService = new ClientService();
        OrderService orderService = new OrderService();
        ApplicationContext context = new ApplicationContext();

        public ActionResult Index()
        {
            return RedirectPermanent("App/Orders");
        }
        //----------------------------ORDERS--------------------------------//
        public ActionResult Orders()
        {
            if (Request.IsAjaxRequest())
            {
                var result = new List<OrderViewModel>();

                using (orderService.Context = context)
                {
                    result = orderService.GetAllOrders();
                }
                return PartialView(result);
            }
            else
            {
                var result = new List<OrderViewModel>();

                using (orderService.Context = context)
                {
                    result = orderService.GetAllOrders();
                }

                return View("OrdersIndex");
            }
        }

        //------------------------------AddOrder--------------------------//
        public ActionResult AddOrder()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddOrder(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                using (orderService.Context = context)
                {
                    orderService.AddOrder(order);
                }

                return RedirectToAction("Index");
            }

            return View(order);
        }

        //---------------------------EditOrder-----------------------------//
        [HttpGet]
        public ActionResult EditOrder(string number)
        {
            var result = new OrderViewModel();
            
            using (orderService.Context = context)
            {
                result = orderService.GetOrder(number);
            }

            return View(result);
        }

        public ActionResult EditOrder(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                using (orderService.Context = context)
                {
                    orderService.UpdateOrder(order);
                }

                return RedirectToAction("Index");
            }

            return View(order);
        }

        //--------------------------DeleteOrder-------------------------//
        public ActionResult DeleteOrder(string numberOrder)
        {
            using (orderService.Context = context)
            {
                orderService.DeleteOrder(numberOrder);
            }
            return RedirectToAction("Index");
        }

        //-------------------------Cashboxs-----------------------------//
        public ActionResult Cashboxs()
        {
            if (Request.IsAjaxRequest()) return PartialView();
            return View("CashboxsIndex");
        }

        //--------------------------Settings----------------------------//
        public ActionResult Settings()
        {
            if (Request.IsAjaxRequest()) return PartialView();
            return View("SettingsIndex");
        }

        public string GetData()
        {
            var result = new List<OrderViewModel>();

            using (orderService.Context = context)
            {
                result = orderService.GetAllOrders();
            }
            var res = JsonConvert.SerializeObject(result);

            return res;
        }
    }
}