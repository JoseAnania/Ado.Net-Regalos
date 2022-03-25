using RegalosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegalosWeb.Controllers
{
    public class ParejaController : Controller
    {
        // GET: Pareja
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Agregar()
        {
            Pareja P = new Pareja();
            GestorPareja gp = new GestorPareja();
            ViewBag.cboComercio = new SelectList(gp.cboComercio(), "idC", "denominacionC");
            return View(P);
        }
        [HttpPost]
        public ActionResult Agregar(Pareja nuevaPareja)
        {
            GestorPareja gp = new GestorPareja();
            gp.AltaPareja(nuevaPareja);
            ViewBag.cboComercio = new SelectList(gp.cboComercio(), "idC", "denominacionC", nuevaPareja.IdC);
            return View("Index");
        }
        public ActionResult Eliminar()
        {
            Pareja P = new Pareja();
            return View(P);
        }

        [HttpPost]
        public ActionResult Eliminar(Pareja borrarPaareja)
        {
            GestorPareja gp = new GestorPareja();
            gp.bajaPareja(borrarPaareja);
            return View("Index");
        }
        public ActionResult Modificar()
        {
            Pareja P = new Pareja();
            GestorPareja gp = new GestorPareja();
            ViewBag.cboComercio = new SelectList(gp.cboComercio(), "idC", "denominacionC");
            return View(P);
        }

        [HttpPost]
        public ActionResult Modificar(Pareja cambiarPareja)
        {
            GestorPareja gp = new GestorPareja();
            gp.modificarPareja(cambiarPareja);
            ViewBag.cboComercio = new SelectList(gp.cboComercio(), "idC", "denominacionC", cambiarPareja.IdC);
            return View("Index");
        }
        public ActionResult Listar()
        {
            GestorPareja GP = new GestorPareja();
            List<ParejaComercioDto> lista = GP.Listar();
            return View(lista);
        }
        public ActionResult SelectPareja()
        {
            GestorPareja GP = new GestorPareja();
            List<ParejaComercioDto> lista = GP.Listar();
            return View(lista);
        }
    }
}