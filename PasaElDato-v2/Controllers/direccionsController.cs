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
    public class direccionsController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: direccions
        public ActionResult Index()
        {
            var direccion = db.direccion.Include(d => d.comuna).Include(d => d.sucursal);
            return View(direccion.ToList());
        }

        // GET: direccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            direccion direccion = db.direccion.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: direccions/Create
        public ActionResult Create()
        {
            ViewBag.idcomuna = new SelectList(db.comuna, "idcomuna", "comuna1");
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre");
            return View();
        }

        // POST: direccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iddireccion,direccion1,numero,idcomuna,idsucursal")] direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.direccion.Add(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcomuna = new SelectList(db.comuna, "idcomuna", "comuna1", direccion.idcomuna);
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre", direccion.idsucursal);
            return View(direccion);
        }

        // GET: direccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            direccion direccion = db.direccion.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcomuna = new SelectList(db.comuna, "idcomuna", "comuna1", direccion.idcomuna);
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre", direccion.idsucursal);
            return View(direccion);
        }

        // POST: direccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iddireccion,direccion1,numero,idcomuna,idsucursal")] direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcomuna = new SelectList(db.comuna, "idcomuna", "comuna1", direccion.idcomuna);
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre", direccion.idsucursal);
            return View(direccion);
        }

        // GET: direccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            direccion direccion = db.direccion.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: direccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            direccion direccion = db.direccion.Find(id);
            db.direccion.Remove(direccion);
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
