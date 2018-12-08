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
    public class puntajesController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: puntajes
        public ActionResult Index()
        {
            return View(db.puntaje.ToList());
        }

        // GET: puntajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            puntaje puntaje = db.puntaje.Find(id);
            if (puntaje == null)
            {
                return HttpNotFound();
            }
            return View(puntaje);
        }

        // GET: puntajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: puntajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idpuntaje,puntaje1")] puntaje puntaje)
        {
            if (ModelState.IsValid)
            {
                db.puntaje.Add(puntaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(puntaje);
        }

        // GET: puntajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            puntaje puntaje = db.puntaje.Find(id);
            if (puntaje == null)
            {
                return HttpNotFound();
            }
            return View(puntaje);
        }

        // POST: puntajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idpuntaje,puntaje1")] puntaje puntaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puntaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(puntaje);
        }

        // GET: puntajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            puntaje puntaje = db.puntaje.Find(id);
            if (puntaje == null)
            {
                return HttpNotFound();
            }
            return View(puntaje);
        }

        // POST: puntajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            puntaje puntaje = db.puntaje.Find(id);
            db.puntaje.Remove(puntaje);
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
