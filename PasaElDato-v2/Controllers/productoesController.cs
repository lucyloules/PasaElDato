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
    public class productoesController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: productoes
        public ActionResult Index()
        {
            var producto = db.producto.Include(p => p.usuario).Include(p => p.tipohabitacion_x_sucursal).Include(p => p.restricciones);
            return View(producto.ToList());
        }

        // GET: productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: productoes/Create
        public ActionResult Create()
        {
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre");
            ViewBag.idsucursal = new SelectList(db.tipohabitacion_x_sucursal, "idsucursal", "idsucursal");
            ViewBag.idrestriccion = new SelectList(db.restricciones, "idrestriccion", "restriccion");
            return View();
        }

        // POST: productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idproducto,descripcion_producto,fecha_ini,fecha_fin,idrestriccion,idsucursal,idtipo_habitacion,precio1,precio2,idusuario,descuento")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre", producto.idusuario);
            ViewBag.idsucursal = new SelectList(db.tipohabitacion_x_sucursal, "idsucursal", "idsucursal", producto.idsucursal);
            ViewBag.idrestriccion = new SelectList(db.restricciones, "idrestriccion", "restriccion", producto.idrestriccion);
            return View(producto);
        }

        // GET: productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre", producto.idusuario);
            ViewBag.idsucursal = new SelectList(db.tipohabitacion_x_sucursal, "idsucursal", "idsucursal", producto.idsucursal);
            ViewBag.idrestriccion = new SelectList(db.restricciones, "idrestriccion", "restriccion", producto.idrestriccion);
            return View(producto);
        }

        // POST: productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idproducto,descripcion_producto,fecha_ini,fecha_fin,idrestriccion,idsucursal,idtipo_habitacion,precio1,precio2,idusuario,descuento")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre", producto.idusuario);
            ViewBag.idsucursal = new SelectList(db.tipohabitacion_x_sucursal, "idsucursal", "idsucursal", producto.idsucursal);
            ViewBag.idrestriccion = new SelectList(db.restricciones, "idrestriccion", "restriccion", producto.idrestriccion);
            return View(producto);
        }

        // GET: productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            producto producto = db.producto.Find(id);
            db.producto.Remove(producto);
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
