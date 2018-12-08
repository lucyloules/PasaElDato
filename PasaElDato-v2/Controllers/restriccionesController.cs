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
    public class restriccionesController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: restricciones
        public ActionResult Index()
        {
            return View(db.restricciones.ToList());
        }

        // GET: restricciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restricciones restricciones = db.restricciones.Find(id);
            if (restricciones == null)
            {
                return HttpNotFound();
            }
            return View(restricciones);
        }

        // GET: restricciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: restricciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idrestriccion,restriccion,descripcion_horario,descripcion_fecha,idproducto,idsucursal,precio")] restricciones restricciones)
        {
            if (ModelState.IsValid)
            {
                db.restricciones.Add(restricciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restricciones);
        }

        // GET: restricciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restricciones restricciones = db.restricciones.Find(id);
            if (restricciones == null)
            {
                return HttpNotFound();
            }
            return View(restricciones);
        }

        // POST: restricciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idrestriccion,restriccion,descripcion_horario,descripcion_fecha,idproducto,idsucursal,precio")] restricciones restricciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restricciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restricciones);
        }

        // GET: restricciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restricciones restricciones = db.restricciones.Find(id);
            if (restricciones == null)
            {
                return HttpNotFound();
            }
            return View(restricciones);
        }

        // POST: restricciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            restricciones restricciones = db.restricciones.Find(id);
            db.restricciones.Remove(restricciones);
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
