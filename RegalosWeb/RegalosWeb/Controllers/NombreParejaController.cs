using RegalosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegalosWeb.Controllers
{
    public class NombreParejaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListaNombrePareja()
        {
            GestorPareja gp = new GestorPareja();
            List<ParejaComercioDto> lista = gp.Listar();
            return View(lista);
        }
    }
}