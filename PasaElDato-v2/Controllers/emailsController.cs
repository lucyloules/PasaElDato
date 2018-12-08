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
    public class emailsController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: emails
        public ActionResult Index()
        {
            var email = db.email.Include(e => e.sucursal);
            return View(email.ToList());
        }

        // GET: emails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            email email = db.email.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        // GET: emails/Create
        public ActionResult Create()
        {
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre");
            return View();
        }

        // POST: emails/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idemail,email1,idsucursal")] email email)
        {
            if (ModelState.IsValid)
            {
                db.email.Add(email);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre", email.idsucursal);
            return View(email);
        }

        // GET: emails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            email email = db.email.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre", email.idsucursal);
            return View(email);
        }

        // POST: emails/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idemail,email1,idsucursal")] email email)
        {
            if (ModelState.IsValid)
            {
                db.Entry(email).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idsucursal = new SelectList(db.sucursal, "idsucursal", "nombre", email.idsucursal);
            return View(email);
        }

        // GET: emails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            email email = db.email.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        // POST: emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            email email = db.email.Find(id);
            db.email.Remove(email);
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
