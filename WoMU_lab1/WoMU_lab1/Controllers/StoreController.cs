using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoMU_lab1.Models;

namespace WoMU_lab1.Controllers
{
    public class StoreController : Controller
    {
        ArticleDBContext storeDB = new ArticleDBContext();

        //
        // GET: /Store/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse()
        {
            return View();
        }

        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var item = storeDB.Article.Find(id);

            return View(item);
        }
    }
}