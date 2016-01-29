using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoMS_lab1.Models;

namespace WoMU_lab1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // TODO: Läs in produkter automagiskt.
            dynamic model = new ExpandoObject();

            model.Order    = new Order();
            model.Products = new[] {
                new Product() { ProductID = "snabel"    , Name = "produkt ett", Price = 10000 },
                new Product() { ProductID = "elefant"   , Name = "produkt två", Price = 10000 },
                new Product() { ProductID = "raketmotor", Name = "produkt tre", Price = 10000 }
            };

            return View(model.Products);
        }

        public ActionResult OrderInfo() {
            return PartialView("_Order", Session["Order"] ?? new Order());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
