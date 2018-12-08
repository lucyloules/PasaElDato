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
    public class imagen_sucursalController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: imagen_sucursal
        public ActionResult Index()
        {
            var imagen_sucursal = db.imagen_sucursal.Include(i => i.sucursal);
            return View(imagen_sucursal.ToList());
        }

        // GET: imagen_sucursal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imagen_sucursal imagen_sucursal = db.imagen_sucursal.Find(id);
            if (imagen_sucursal == null)
            {
                return HttpNotFound();
            }
            return View(imagen_sucursal);
        }

        // GET: imagen_sucursal/Create
        public ActionResult Create()
        {
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre");
            return View();
        }

        // POST: imagen_sucursal/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idimagensucursal,path_imagensucursal,idsucursal")] imagen_sucursal imagen_sucursal)
        {
            if (ModelState.IsValid)
            {
                db.imagen_sucursal.Add(imagen_sucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre", imagen_sucursal.idsucursal);
            return View(imagen_sucursal);
        }

        // GET: imagen_sucursal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imagen_sucursal imagen_sucursal = db.imagen_sucursal.Find(id);
            if (imagen_sucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre", imagen_sucursal.idsucursal);
            return View(imagen_sucursal);
        }

        // POST: imagen_sucursal/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idimagensucursal,path_imagensucursal,idsucursal")] imagen_sucursal imagen_sucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagen_sucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre", imagen_sucursal.idsucursal);
            return View(imagen_sucursal);
        }

        // GET: imagen_sucursal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imagen_sucursal imagen_sucursal = db.imagen_sucursal.Find(id);
            if (imagen_sucursal == null)
            {
                return HttpNotFound();
            }
            return View(imagen_sucursal);
        }

        // POST: imagen_sucursal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            imagen_sucursal imagen_sucursal = db.imagen_sucursal.Find(id);
            db.imagen_sucursal.Remove(imagen_sucursal);
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
