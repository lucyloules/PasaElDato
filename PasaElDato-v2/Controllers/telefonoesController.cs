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
    public class telefonoesController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: telefonoes
        public ActionResult Index()
        {
            var telefono = db.telefono.Include(t => t.sucursal);
            return View(telefono.ToList());
        }

        // GET: telefonoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefono telefono = db.telefono.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // GET: telefonoes/Create
        public ActionResult Create()
        {
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre");
            return View();
        }

        // POST: telefonoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtelefono,telefono1,idsucursal")] telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.telefono.Add(telefono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre", telefono.idsucursal);
            return View(telefono);
        }

        // GET: telefonoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefono telefono = db.telefono.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre", telefono.idsucursal);
            return View(telefono);
        }

        // POST: telefonoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtelefono,telefono1,idsucursal")] telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre", telefono.idsucursal);
            return View(telefono);
        }

        // GET: telefonoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefono telefono = db.telefono.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // POST: telefonoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            telefono telefono = db.telefono.Find(id);
            db.telefono.Remove(telefono);
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
