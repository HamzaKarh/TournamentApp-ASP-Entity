using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        [Authorize (Roles = "user,admin")]
        public ActionResult User_page()
        {
            return View();
        }

        /* Si l'utilisateur n'est pas un admin, il sera redirigé vers la page login pour qu'il se connecte en tant qu'admin */
        [Authorize (Roles = "admin")]
        public ActionResult Admin_page()
        {
            return View();
        }
    }
}