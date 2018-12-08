using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PasaElDato_v2.Models;

namespace PasaElDato_v2.Controllers
{
    public class servicio_habitacionController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: servicio_habitacion
        public ActionResult Index()
        {
            return View(db.servicio_habitacion.ToList());
        }

        // GET: servicio_habitacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicio_habitacion servicio_habitacion = db.servicio_habitacion.Find(id);
            if (servicio_habitacion == null)
            {
                return HttpNotFound();
            }
            return View(servicio_habitacion);
        }

        // GET: servicio_habitacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: servicio_habitacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idserviciohabitacion,descriocion_serviciohabitacion")] servicio_habitacion servicio_habitacion)
        {
            if (ModelState.IsValid)
            {
                db.servicio_habitacion.Add(servicio_habitacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicio_habitacion);
        }

        // GET: servicio_habitacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicio_habitacion servicio_habitacion = db.servicio_habitacion.Find(id);
            if (servicio_habitacion == null)
            {
                return HttpNotFound();
            }
            return View(servicio_habitacion);
        }

        // POST: servicio_habitacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idserviciohabitacion,descriocion_serviciohabitacion")] servicio_habitacion servicio_habitacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicio_habitacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicio_habitacion);
        }

        // GET: servicio_habitacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicio_habitacion servicio_habitacion = db.servicio_habitacion.Find(id);
            if (servicio_habitacion == null)
            {
                return HttpNotFound();
            }
            return View(servicio_habitacion);
        }

        // POST: servicio_habitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            servicio_habitacion servicio_habitacion = db.servicio_habitacion.Find(id);
            db.servicio_habitacion.Remove(servicio_habitacion);
            db.SaveChanges();
            return RedirectToAction("Index");
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
