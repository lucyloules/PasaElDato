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
    public class horasController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: horas
        public ActionResult Index()
        {
            var horas = db.horas.Include(h => h.estado);
            return View(horas.ToList());
        }

        // GET: horas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            horas horas = db.horas.Find(id);
            if (horas == null)
            {
                return HttpNotFound();
            }
            return View(horas);
        }

        // GET: horas/Create
        public ActionResult Create()
        {
            ViewBag.idestado = new SelectList(db.estado, "idestado", "estado1");
            return View();
        }

        // POST: horas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idhora,dia,hora,fecha,idestado")] horas horas)
        {
            if (ModelState.IsValid)
            {
                db.horas.Add(horas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idestado = new SelectList(db.estado, "idestado", "estado1", horas.idestado);
            return View(horas);
        }

        // GET: horas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            horas horas = db.horas.Find(id);
            if (horas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idestado = new SelectList(db.estado, "idestado", "estado1", horas.idestado);
            return View(horas);
        }

        // POST: horas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idhora,dia,hora,fecha,idestado")] horas horas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idestado = new SelectList(db.estado, "idestado", "estado1", horas.idestado);
            return View(horas);
        }

        // GET: horas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            horas horas = db.horas.Find(id);
            if (horas == null)
            {
                return HttpNotFound();
            }
            return View(horas);
        }

        // POST: horas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            horas horas = db.horas.Find(id);
            db.horas.Remove(horas);
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
