using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sobre Nós.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contactos.";

            return View();
        }
    }
}