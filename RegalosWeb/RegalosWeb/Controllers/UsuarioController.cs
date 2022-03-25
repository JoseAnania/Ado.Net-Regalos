using RegalosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegalosWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            Usuario U = new Usuario();
            return View(U);
        }
        [HttpPost]
        public ActionResult Login(string nombreU, string contrasenia)
        {
            GestorUsuario gu = new GestorUsuario();

            if (gu.ingresoAdm(nombreU, contrasenia))
            {
                return View("~/Views/Usuario/MenuAdmin.cshtml");
                
            }
            else
            {
                return View("~Views/Articulo/Agregar");

            }          
        }
        public ActionResult MenuAdmin()
        {
            return View();
        }
    }
}