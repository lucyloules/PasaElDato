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
    public class puntaje_x_categoriaController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: puntaje_x_categoria
        public ActionResult Index()
        {
            var puntaje_x_categoria = db.puntaje_x_categoria.Include(p => p.categoria).Include(p => p.puntaje);
            return View(puntaje_x_categoria.ToList());
        }

        // GET: puntaje_x_categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            puntaje_x_categoria puntaje_x_categoria = db.puntaje_x_categoria.Find(id);
            if (puntaje_x_categoria == null)
            {
                return HttpNotFound();
            }
            return View(puntaje_x_categoria);
        }

        // GET: puntaje_x_categoria/Create
        public ActionResult Create()
        {
            ViewBag.idcategoria = new SelectList(db.categoria, "idcategoria", "categoria1");
            ViewBag.idpuntaje = new SelectList(db.puntaje, "idpuntaje", "puntaje1");
            return View();
        }

        // POST: puntaje_x_categoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idpuntaje,idcategoria")] puntaje_x_categoria puntaje_x_categoria)
        {
            if (ModelState.IsValid)
            {
                db.puntaje_x_categoria.Add(puntaje_x_categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcategoria = new SelectList(db.categoria, "idcategoria", "categoria1", puntaje_x_categoria.idcategoria);
            ViewBag.idpuntaje = new SelectList(db.puntaje, "idpuntaje", "puntaje1", puntaje_x_categoria.idpuntaje);
            return View(puntaje_x_categoria);
        }

        // GET: puntaje_x_categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            puntaje_x_categoria puntaje_x_categoria = db.puntaje_x_categoria.Find(id);
            if (puntaje_x_categoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcategoria = new SelectList(db.categoria, "idcategoria", "categoria1", puntaje_x_categoria.idcategoria);
            ViewBag.idpuntaje = new SelectList(db.puntaje, "idpuntaje", "puntaje1", puntaje_x_categoria.idpuntaje);
            return View(puntaje_x_categoria);
        }

        // POST: puntaje_x_categoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idpuntaje,idcategoria")] puntaje_x_categoria puntaje_x_categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puntaje_x_categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcategoria = new SelectList(db.categoria, "idcategoria", "categoria1", puntaje_x_categoria.idcategoria);
            ViewBag.idpuntaje = new SelectList(db.puntaje, "idpuntaje", "puntaje1", puntaje_x_categoria.idpuntaje);
            return View(puntaje_x_categoria);
        }

        // GET: puntaje_x_categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            puntaje_x_categoria puntaje_x_categoria = db.puntaje_x_categoria.Find(id);
            if (puntaje_x_categoria == null)
            {
                return HttpNotFound();
            }
            return View(puntaje_x_categoria);
        }

        // POST: puntaje_x_categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            puntaje_x_categoria puntaje_x_categoria = db.puntaje_x_categoria.Find(id);
            db.puntaje_x_categoria.Remove(puntaje_x_categoria);
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
