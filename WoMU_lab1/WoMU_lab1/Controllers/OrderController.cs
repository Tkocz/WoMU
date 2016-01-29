using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoMS_lab1.Models;

namespace WoMU_lab1.Controllers {
    public class OrderController : Controller {
        [HttpPost]
        public void AddProduct(string productID) {
            Order order = (Order)Session["Order"];
            if (order == null) {
                order = new Order();
                Session["Order"] = order;
            }

            var product = new Product() { ProductID = productID, Description = "god damnit" };

            order.AddProduct(product);
        }
    }
}
