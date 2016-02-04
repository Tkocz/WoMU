﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WoMU_lab1.Models;

namespace WoMU_lab1.Controllers
{
    public class OrdersController : Controller
    {
        private ArticleDBContext db = new ArticleDBContext();

        // GET: Orders
        public async Task<ActionResult> Index()
        {
            return View(await db.Order.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Order.FindAsync(id);
            var orderDetails = db.OrderDetails.Where(x => x.OrderId == id);

            order.OrderDetails = await orderDetails.ToListAsync();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                var cart = ShoppingCart.GetCart(this.HttpContext);
                order.OrderDetails = new List<OrderDetail>();//new ArticleDBContext().Set<OrderDetail>();
                order.OrderTotal = 0;
                foreach (var c in cart.GetCartItems()) {
                    order.OrderDetails.Add(new OrderDetail() { ArticleId = c.ArticleId, OrderId = order.OrderId, Quantity = c.Count, UnitPrice = c.Article.ArticlePrice });
                    order.OrderTotal += c.Article.ArticlePrice * c.Count;

                    var art = db.Article.Where(a => a.ArticleId == c.Article.ArticleId).Single();
                    art.ArticleInStock -= c.Count;
                    if (art.ArticleInStock < 0)
                        art.ArticleInStock = 0;
                }
                db.Order.Add(order);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Order.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Order.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Order order = await db.Order.FindAsync(id);
            db.Order.Remove(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
