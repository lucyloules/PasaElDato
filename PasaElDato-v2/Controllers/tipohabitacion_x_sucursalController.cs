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
    public class tipohabitacion_x_sucursalController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: tipohabitacion_x_sucursal
        public ActionResult Index()
        {
            var tipohabitacion_x_sucursal = db.tipohabitacion_x_sucursal.Include(t => t.sucursal).Include(t => t.tipo_habitacion);
            return View(tipohabitacion_x_sucursal.ToList());
        }

        // GET: tipohabitacion_x_sucursal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipohabitacion_x_sucursal tipohabitacion_x_sucursal = db.tipohabitacion_x_sucursal.Find(id);
            if (tipohabitacion_x_sucursal == null)
            {
                return HttpNotFound();
            }
            return View(tipohabitacion_x_sucursal);
        }

        // GET: tipohabitacion_x_sucursal/Create
        public ActionResult Create()
        {
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre");
            ViewBag.idtipo_habitacion = new SelectList(db.tipo_habitacion, "idtipo_habitacion", "descripcion_tipohabitacion");
            return View();
        }

        // POST: tipohabitacion_x_sucursal/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idsucursal,idtipo_habitacion")] tipohabitacion_x_sucursal tipohabitacion_x_sucursal)
        {
            if (ModelState.IsValid)
            {
                db.tipohabitacion_x_sucursal.Add(tipohabitacion_x_sucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre", tipohabitacion_x_sucursal.idsucursal);
            ViewBag.idtipo_habitacion = new SelectList(db.tipo_habitacion, "idtipo_habitacion", "descripcion_tipohabitacion", tipohabitacion_x_sucursal.idtipo_habitacion);
            return View(tipohabitacion_x_sucursal);
        }

        // GET: tipohabitacion_x_sucursal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipohabitacion_x_sucursal tipohabitacion_x_sucursal = db.tipohabitacion_x_sucursal.Find(id);
            if (tipohabitacion_x_sucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre", tipohabitacion_x_sucursal.idsucursal);
            ViewBag.idtipo_habitacion = new SelectList(db.tipo_habitacion, "idtipo_habitacion", "descripcion_tipohabitacion", tipohabitacion_x_sucursal.idtipo_habitacion);
            return View(tipohabitacion_x_sucursal);
        }

        // POST: tipohabitacion_x_sucursal/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idsucursal,idtipo_habitacion")] tipohabitacion_x_sucursal tipohabitacion_x_sucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipohabitacion_x_sucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre", tipohabitacion_x_sucursal.idsucursal);
            ViewBag.idtipo_habitacion = new SelectList(db.tipo_habitacion, "idtipo_habitacion", "descripcion_tipohabitacion", tipohabitacion_x_sucursal.idtipo_habitacion);
            return View(tipohabitacion_x_sucursal);
        }

        // GET: tipohabitacion_x_sucursal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipohabitacion_x_sucursal tipohabitacion_x_sucursal = db.tipohabitacion_x_sucursal.Find(id);
            if (tipohabitacion_x_sucursal == null)
            {
                return HttpNotFound();
            }
            return View(tipohabitacion_x_sucursal);
        }

        // POST: tipohabitacion_x_sucursal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipohabitacion_x_sucursal tipohabitacion_x_sucursal = db.tipohabitacion_x_sucursal.Find(id);
            db.tipohabitacion_x_sucursal.Remove(tipohabitacion_x_sucursal);
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
