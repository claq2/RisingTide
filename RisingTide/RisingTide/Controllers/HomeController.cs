using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RisingTide.DataAccess;

namespace RisingTide.Controllers
{
    public class HomeController : Controller
    {
        IDomainContext context = new RisingTideContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            string x = "user";
            Models.User y = this.context.Users.FirstOrDefault(u => u.Username == x);
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            this.context.Dispose();
            base.Dispose(disposing);
        }
    }
}
