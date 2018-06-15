using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaTekusAPP.Models;

namespace PruebaTekusAPP.Controllers
{
    public class ClientesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nit,Nombre,Correo")] Clientes clientes)
        {

            var validate = (from c in db.Clientes
                            where c.Nit == clientes.Nit
                            select c).FirstOrDefault();

            if (validate == null)
            {
                if (ModelState.IsValid)
                {


                    db.Clientes.Add(clientes);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(clientes);
            }
            else
            {
                ViewBag.PageTitle = "Este ya se encuentra registrado";
                return View();
            }

            
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nit,Nombre,Correo")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult VerServicios(int id) {

            try
            {
                var ServiciosClientes = (from s in db.Servicios
                                         join sc in db.ServiciosCliente on s.Id equals sc.IdServicio
                                         join c in db.Clientes on sc.IdCliente equals c.Id
                                         where c.Id == id
                                         select s).Distinct().ToList();
                    

                return Json(new { success = true, Services = ServiciosClientes,JsonRequestBehavior.AllowGet });

            }
            catch (Exception)
            {

                return Json(new { success = false });
            }
           

        }


      
        public JsonResult VerPais()
        {

            try
            {
                var pais = (from p in db.Pais
                                         
                                         select p).ToList();


                return Json(new { success = true, Paises = pais},JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                return Json(new { success = false });
            }


        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
