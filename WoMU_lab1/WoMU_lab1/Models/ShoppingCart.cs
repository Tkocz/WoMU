using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WoMU_lab1.Models
{
    public partial class ShoppingCart
    {
        ArticleDBContext DB = new ArticleDBContext();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public int AddToCart(Article article)
        {
            // Get the matching cart and item instances
            var cartItem = DB.Carts.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ArticleId == article.ArticleId);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart
                {
                    ArticleId = article.ArticleId,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                DB.Carts.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Count++;
            }
            // Save changes
            DB.SaveChanges();

            return cartItem.Count;
        }

        public int RemoveFromCart(int id)
        {


            // Get the cart

            var cartItem = DB.Carts.Single(
                cart => cart.CartId == ShoppingCartId
                && cart.ArticleId == id);


            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    DB.Carts.Remove(cartItem);
                }
                // Save changes
                DB.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = DB.Carts.Where(
                cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                DB.Carts.Remove(cartItem);
            }
            // Save changes
            DB.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return DB.Carts.Where(
                cart => cart.CartId == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in DB.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (from cartItems in DB.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count *
                              cartItems.Article.ArticlePrice).Sum();

            return total ?? decimal.Zero;
        }

        public Order CreateOrder(Order order)
        {
            decimal orderTotal = 0;
            order.OrderDetails = new List<OrderDetail>();

            var cartItems = GetCartItems();
            foreach (var article in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ArticleId = article.ArticleId,
                    OrderId = order.OrderId,
                    UnitPrice = article.Article.ArticlePrice,
                    Quantity = article.Count
                };
            
                orderTotal += (article.Count * article.Article.ArticlePrice);
                order.OrderDetails.Add(orderDetail);
                DB.OrderDetails.Add(orderDetail);
                
                var art = DB.Article.Where(a => a.ArticleId == article.Article.ArticleId).Single();
                art.ArticleInStock -= article.Count;
                if (art.ArticleInStock < 0)
                    art.ArticleInStock = 0;

            }
            // Set the order's total to the orderTotal count
            order.OrderTotal = orderTotal;

            DB.SaveChanges();

            EmptyCart();
            // Return the OrderId as the confirmation number
            return order;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
    }
}