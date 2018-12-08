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
    public class comunasController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: comunas
        public ActionResult Index()
        {
            var comuna = db.comuna.Include(c => c.region);
            return View(comuna.ToList());
        }

        // GET: comunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comuna comuna = db.comuna.Find(id);
            if (comuna == null)
            {
                return HttpNotFound();
            }
            return View(comuna);
        }

        // GET: comunas/Create
        public ActionResult Create()
        {
            ViewBag.idregion = new SelectList(db.region, "idregion", "region1");
            return View();
        }

        // POST: comunas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcomuna,comuna1,idregion")] comuna comuna)
        {
            if (ModelState.IsValid)
            {
                db.comuna.Add(comuna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idregion = new SelectList(db.region, "idregion", "region1", comuna.idregion);
            return View(comuna);
        }

        // GET: comunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comuna comuna = db.comuna.Find(id);
            if (comuna == null)
            {
                return HttpNotFound();
            }
            ViewBag.idregion = new SelectList(db.region, "idregion", "region1", comuna.idregion);
            return View(comuna);
        }

        // POST: comunas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcomuna,comuna1,idregion")] comuna comuna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comuna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idregion = new SelectList(db.region, "idregion", "region1", comuna.idregion);
            return View(comuna);
        }

        // GET: comunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comuna comuna = db.comuna.Find(id);
            if (comuna == null)
            {
                return HttpNotFound();
            }
            return View(comuna);
        }

        // POST: comunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            comuna comuna = db.comuna.Find(id);
            db.comuna.Remove(comuna);
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
