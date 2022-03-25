using RegalosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegalosWeb.Controllers
{
    public class ArticuloController : Controller
    {
        // GET: Articulo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Agregar()
        {
            Articulo A = new Articulo();
            GestorArticulo ga = new GestorArticulo();
            ViewBag.cboTipoArticulo = new SelectList(ga.cboTipoArticulo(), "idTA", "denominacionTA");
            return View(A);
        }
        [HttpPost]
        public ActionResult Agregar(Articulo nuevoArticulo)
        {
            GestorArticulo ga = new GestorArticulo();
            ga.AltaArticulo(nuevoArticulo);
            ViewBag.cboTipoArticulo = new SelectList(ga.cboTipoArticulo(), "idTA", "denominacionTA", nuevoArticulo.IdA);
            return View("Index");
        }
        public ActionResult Eliminar()
        {
            Articulo A = new Articulo();
            return View(A);
        }

        [HttpPost]
        public ActionResult Eliminar(Articulo nuevoArticulo)
        {
            GestorArticulo ga = new GestorArticulo();
            ga.bajaArticulo(nuevoArticulo);
            return View("Index");
        }
        public ActionResult Modificar()
        {
            Articulo A = new Articulo();
            GestorArticulo ga = new GestorArticulo();
            ViewBag.cboTipoArticulo = new SelectList(ga.cboTipoArticulo(), "idTA", "denominacionTA");
            return View(A);
        }

        [HttpPost]
        public ActionResult Modificar(Articulo cambiarArticulo)
        {
            GestorArticulo ga = new GestorArticulo();
            ga.modificarArticulo(cambiarArticulo);
            ViewBag.cboTipoArticulo = new SelectList(ga.cboTipoArticulo(), "idTA", "denominacionTA", cambiarArticulo.IdA);
            return View("Index");
        }
        public ActionResult Listar()
        {
            GestorArticulo GA = new GestorArticulo();
            List<ArticuloTipoDto> lista = GA.Listar();
            return View(lista);
        }
    }
}