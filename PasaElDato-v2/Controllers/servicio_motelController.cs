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
    public class servicio_motelController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: servicio_motel
        public ActionResult Index()
        {
            return View(db.servicio_motel.ToList());
        }

        // GET: servicio_motel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicio_motel servicio_motel = db.servicio_motel.Find(id);
            if (servicio_motel == null)
            {
                return HttpNotFound();
            }
            return View(servicio_motel);
        }

        // GET: servicio_motel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: servicio_motel/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idserviciomotel,descripcion_serviciomotel")] servicio_motel servicio_motel)
        {
            if (ModelState.IsValid)
            {
                db.servicio_motel.Add(servicio_motel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicio_motel);
        }

        // GET: servicio_motel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicio_motel servicio_motel = db.servicio_motel.Find(id);
            if (servicio_motel == null)
            {
                return HttpNotFound();
            }
            return View(servicio_motel);
        }

        // POST: servicio_motel/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idserviciomotel,descripcion_serviciomotel")] servicio_motel servicio_motel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicio_motel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicio_motel);
        }

        // GET: servicio_motel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicio_motel servicio_motel = db.servicio_motel.Find(id);
            if (servicio_motel == null)
            {
                return HttpNotFound();
            }
            return View(servicio_motel);
        }

        // POST: servicio_motel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            servicio_motel servicio_motel = db.servicio_motel.Find(id);
            db.servicio_motel.Remove(servicio_motel);
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
