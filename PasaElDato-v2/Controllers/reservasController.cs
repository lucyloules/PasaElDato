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
    public class reservasController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: reservas
        public ActionResult Index()
        {
            var reserva = db.reserva.Include(r => r.horas).Include(r => r.producto).Include(r => r.usuario);
            return View(reserva.ToList());
        }

        // GET: reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva reserva = db.reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: reservas/Create
        public ActionResult Create()
        {
            ViewBag.idhora = new SelectList(db.horas, "idhora", "dia");
            ViewBag.idproducto = new SelectList(db.producto, "idproducto", "descripcion_producto");
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre");
            return View();
        }

        // POST: reservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idreserva,idusuario,idproducto,idhora")] reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.reserva.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idhora = new SelectList(db.horas, "idhora", "dia", reserva.idhora);
            ViewBag.idproducto = new SelectList(db.producto, "idproducto", "descripcion_producto", reserva.idproducto);
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre", reserva.idusuario);
            return View(reserva);
        }

        // GET: reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva reserva = db.reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.idhora = new SelectList(db.horas, "idhora", "dia", reserva.idhora);
            ViewBag.idproducto = new SelectList(db.producto, "idproducto", "descripcion_producto", reserva.idproducto);
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre", reserva.idusuario);
            return View(reserva);
        }

        // POST: reservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idreserva,idusuario,idproducto,idhora")] reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idhora = new SelectList(db.horas, "idhora", "dia", reserva.idhora);
            ViewBag.idproducto = new SelectList(db.producto, "idproducto", "descripcion_producto", reserva.idproducto);
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre", reserva.idusuario);
            return View(reserva);
        }

        // GET: reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva reserva = db.reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reserva reserva = db.reserva.Find(id);
            db.reserva.Remove(reserva);
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
