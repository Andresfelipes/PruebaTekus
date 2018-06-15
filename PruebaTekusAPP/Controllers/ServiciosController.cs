using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaTekusAPP.Models;
using PruebaTekusAPP.ViewModels;

namespace PruebaTekusAPP.Controllers
{
    public class ServiciosController : Controller
    {
        private Model1 db = new Model1();

        // GET: Servicios
        public ActionResult Index()
        {

            var servicios = (from s in db.Servicios
                             join sc in db.ServiciosCliente on s.Id equals sc.IdServicio
                             join  c in db.Clientes on sc.IdCliente equals c.Id
                             select  new ServicioDTO {
                                 Id =s.Id,
                                 Nombre = s.Nombre,
                                 ValorHora = s.ValorHora,
                                 NombleCliente = c.Nombre
                             }).ToList();

            return View(servicios.ToList());
        }

        // GET: Servicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,ValorHora")] Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Servicios.Add(servicios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicios);
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // POST: Servicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,ValorHora")] Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicios);
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicios servicios = db.Servicios.Find(id);
            db.Servicios.Remove(servicios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult GuardarServicio(ServivioViewModel Servicio)
        {
            //Se inicializan variables.
            ServiciosCliente _ServicioCliente = new ServiciosCliente();
            Servicios _servivio = new Servicios();

            //Se Gurada el servicio
            _servivio.Nombre = Servicio.Servicios.Nombre;
            _servivio.ValorHora = Servicio.Servicios.ValorHora;

            var ServicioCreate = db.Servicios.Add(_servivio);
            db.SaveChanges();

            //Se crea el registro entre la tabla servicios y la tabla clientes
            _ServicioCliente.IdCliente = Servicio.IdCliente;
            _ServicioCliente.IdServicio = ServicioCreate.Id;

            db.ServiciosCliente.Add(_ServicioCliente);
            db.SaveChanges();


            //Se agregan los paises en los que se ofrece el servicio 
            foreach (var item in Servicio.Paises)
            {
                PaisServicio _pais = new PaisServicio();
                _pais.IdPais = item.Id;
                _pais.IdServicio = ServicioCreate.Id;
                db.PaisServicio.Add(_pais);
                db.SaveChanges();
            }

          

            return Json(new { success = true });
        }


        [HttpPost]
        public JsonResult VerPaises(int id)
        {   

            try
            {
                var ServiciosClientes = (from p in db.Pais
                                         join ps in db.PaisServicio on p.Id equals ps.IdPais
                                         join s in db.Servicios on ps.IdServicio equals s.Id
                                         where  ps.IdServicio == id
                                         select p).ToList();


                return Json(new { success = true, Paises = ServiciosClientes, JsonRequestBehavior.AllowGet });

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
