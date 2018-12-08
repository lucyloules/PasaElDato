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
    public class tipo_habitacionController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: tipo_habitacion
        public ActionResult Index()
        {
            return View(db.tipo_habitacion.ToList());
        }

        // GET: tipo_habitacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_habitacion tipo_habitacion = db.tipo_habitacion.Find(id);
            if (tipo_habitacion == null)
            {
                return HttpNotFound();
            }
            return View(tipo_habitacion);
        }

        // GET: tipo_habitacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_habitacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtipo_habitacion,descripcion_tipohabitacion,link")] tipo_habitacion tipo_habitacion)
        {
            if (ModelState.IsValid)
            {
                db.tipo_habitacion.Add(tipo_habitacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_habitacion);
        }

        // GET: tipo_habitacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_habitacion tipo_habitacion = db.tipo_habitacion.Find(id);
            if (tipo_habitacion == null)
            {
                return HttpNotFound();
            }
            return View(tipo_habitacion);
        }

        // POST: tipo_habitacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtipo_habitacion,descripcion_tipohabitacion,link")] tipo_habitacion tipo_habitacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_habitacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_habitacion);
        }

        // GET: tipo_habitacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_habitacion tipo_habitacion = db.tipo_habitacion.Find(id);
            if (tipo_habitacion == null)
            {
                return HttpNotFound();
            }
            return View(tipo_habitacion);
        }

        // POST: tipo_habitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_habitacion tipo_habitacion = db.tipo_habitacion.Find(id);
            db.tipo_habitacion.Remove(tipo_habitacion);
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
