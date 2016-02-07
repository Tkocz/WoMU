using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoMU_lab1.Models;

namespace WoMU_lab1.Controllers
{
    public class ShoppingCartController : Controller
    {

        ArticleDBContext DB = new ArticleDBContext();
        
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartVM
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }

        public ActionResult ArticleAdded(int artId)
        {
            return View(new AddedArticleModel() { Article = DB.Article.Where(a => a.ArticleId == artId).Single(), Related = RelatedProducts.GetRelatedArticles(DB, artId, 3) });
        }

        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            var addedItem = DB.Article
                .Single(item => item.ArticleId == id);

            var cart = ShoppingCart.GetCart(this.HttpContext);

            int count = cart.AddToCart(addedItem);

            var results = new ShoppingCartRemVM
            {
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = count,
                DeleteId = id
            };
            return RedirectToAction("ArticleAdded", new { artId = id });
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {

            var cart = ShoppingCart.GetCart(this.HttpContext);
            string itemName = DB.Article
                .Single(item => item.ArticleId == id).ArticleName;

            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemVM
            {
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");

        }
    }
}
