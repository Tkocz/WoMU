using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WoMU_lab1.Models;

namespace WoMU_lab1.Controllers
{
    [Authorize]
    public class OrderPlacementController : Controller
    {
        ArticleDBContext DB = new ArticleDBContext();

        // GET: /Checkout/OrderPlacement
        public ActionResult OrderPlacement()
    {
        return View();
    }

        //
        // POST: /Checkout/OrderPlacement
        [HttpPost]
    public async Task<ActionResult> OrderPlacement(FormCollection values)
    {

        var order = new Order();
        TryUpdateModel(order);

        try
        {
            order.OrderFName = User.Identity.Name;
            order.OrderEmail = User.Identity.Name;
            order.OrderDate = DateTime.Now;

            //Save Order
            DB.Order.Add(order);
            await DB.SaveChangesAsync();
            //Process the order
            var cart = ShoppingCart.GetCart(this.HttpContext);
            order = cart.CreateOrder(order);

         return RedirectToAction("Complete",
                new { id = order.OrderId });

        }
        catch
        {
            //Invalid - redisplay with errors
            return View(order);
        }
    }

    //
    // GET: /Checkout/Complete
    public ActionResult Complete(int id)
    {
        // Validate customer owns this order
        bool isValid = DB.Order.Any(
            o => o.OrderId == id);

        if (isValid)
        {
            return View(id);
        }
        else
        {
            return View("Error");
        }
    }
}
}