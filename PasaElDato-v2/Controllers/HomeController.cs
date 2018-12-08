using PasaElDato_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PasaElDato_v2.Controllers
{
    public class HomeController : Controller
    {
        pasaelda_PasaelDatoEntities db = new pasaelda_PasaelDatoEntities();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Contact()
        {
            
            return View();
        }

        public ActionResult Ingresar(string user, string pass)
        {
            usuario use = db.usuario.SingleOrDefault(x=>x.email==user && x.contrasena==pass);
            if (use!=null)
            {
                Session["usuarioActivo"] = use;
            }

            return View();
        }

        public ActionResult Registrar()
        {

            return View();
        }
    }
}