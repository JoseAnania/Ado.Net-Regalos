using RegalosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegalosWeb.Controllers
{
    public class RegaloController : Controller
    {
        // GET: Regalo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Agregar()
        {
            Regalo R = new Regalo();
            GestorInvitado gi = new GestorInvitado();
            GestorArticulo ga = new GestorArticulo();
            ViewBag.cboPareja = new SelectList(gi.cboPareja(), "idP", "nombre1");
            ViewBag.cboArticulo = new SelectList(ga.Listar(), "idA", "denominacionA");
            return View(R);
        }
        [HttpPost]
        public ActionResult Agregar(Regalo nuevoRegalo)
        {
            GestorRegalo gr = new GestorRegalo();
            GestorInvitado gi = new GestorInvitado();
            GestorArticulo ga = new GestorArticulo();
            gr.AltaRegalo(nuevoRegalo);
            ViewBag.cboPareja = new SelectList(gi.cboPareja(), "idP", "nombre1", nuevoRegalo.IdP);
            ViewBag.cboArticulo = new SelectList(ga.Listar(), "idA", "denominacionA", nuevoRegalo.IdA);
            return View("Index");
        }
    }
}