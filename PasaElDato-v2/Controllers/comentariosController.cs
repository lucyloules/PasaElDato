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
    public class comentariosController : Controller
    {
        private pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();

        // GET: comentarios
        public ActionResult Index()
        {
            var comentario = db.comentario.Include(c => c.usuario).Include(c => c.puntaje_x_categoria);
            return View(comentario.ToList());
        }

        // GET: comentarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comentario comentario = db.comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // GET: comentarios/Create
        public ActionResult Create()
        {
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre");
            ViewBag.idpuntaje = new SelectList(db.puntaje_x_categoria, "idpuntaje", "idpuntaje");
            return View();
        }

        // POST: comentarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcomentario,comentario1,fecha,idpuntaje,idusuario,idcategoria")] comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.comentario.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre", comentario.idusuario);
            ViewBag.idpuntaje = new SelectList(db.puntaje_x_categoria, "idpuntaje", "idpuntaje", comentario.idpuntaje);
            return View(comentario);
        }

        // GET: comentarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comentario comentario = db.comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre", comentario.idusuario);
            ViewBag.idpuntaje = new SelectList(db.puntaje_x_categoria, "idpuntaje", "idpuntaje", comentario.idpuntaje);
            return View(comentario);
        }

        // POST: comentarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcomentario,comentario1,fecha,idpuntaje,idusuario,idcategoria")] comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre", comentario.idusuario);
            ViewBag.idpuntaje = new SelectList(db.puntaje_x_categoria, "idpuntaje", "idpuntaje", comentario.idpuntaje);
            return View(comentario);
        }

        // GET: comentarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comentario comentario = db.comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            comentario comentario = db.comentario.Find(id);
            db.comentario.Remove(comentario);
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
