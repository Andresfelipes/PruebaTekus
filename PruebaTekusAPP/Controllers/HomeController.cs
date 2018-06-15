using PruebaTekusAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTekusAPP.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();

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

        [HttpPost]
        public JsonResult VerResumen()
        {
            var Clientes = (from c in db.Clientes

                            select c).Count();

            var Servicios = (from s in db.Servicios

                             select s).Count();



            return Json(new {success = true ,Clientes = Clientes,Servicios = Servicios ,JsonRequestBehavior.AllowGet});
        }
    }
}