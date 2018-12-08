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
    public class imagen_productoController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: imagen_producto
        public ActionResult Index()
        {
            return View(db.imagen_producto.ToList());
        }

        // GET: imagen_producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imagen_producto imagen_producto = db.imagen_producto.Find(id);
            if (imagen_producto == null)
            {
                return HttpNotFound();
            }
            return View(imagen_producto);
        }

        // GET: imagen_producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: imagen_producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idimagenproducto,path_imagenproducto")] imagen_producto imagen_producto)
        {
            if (ModelState.IsValid)
            {
                db.imagen_producto.Add(imagen_producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imagen_producto);
        }

        // GET: imagen_producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imagen_producto imagen_producto = db.imagen_producto.Find(id);
            if (imagen_producto == null)
            {
                return HttpNotFound();
            }
            return View(imagen_producto);
        }

        // POST: imagen_producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idimagenproducto,path_imagenproducto")] imagen_producto imagen_producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagen_producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imagen_producto);
        }

        // GET: imagen_producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imagen_producto imagen_producto = db.imagen_producto.Find(id);
            if (imagen_producto == null)
            {
                return HttpNotFound();
            }
            return View(imagen_producto);
        }

        // POST: imagen_producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            imagen_producto imagen_producto = db.imagen_producto.Find(id);
            db.imagen_producto.Remove(imagen_producto);
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
