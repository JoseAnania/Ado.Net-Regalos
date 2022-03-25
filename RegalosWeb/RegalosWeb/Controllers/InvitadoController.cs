using RegalosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegalosWeb.Controllers
{
    public class InvitadoController : Controller
    {
        // GET: Invitado
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Agregar()
        {
            Invitado I = new Invitado();
            GestorInvitado gi = new GestorInvitado();
            ViewBag.cboPareja = new SelectList(gi.cboPareja(), "idP", "nombre1");
            ViewBag.cboTipoRelacion = new SelectList(gi.cboTipoRelacion(), "idTR", "nombreTR");
            return View(I);
        }
        [HttpPost]
        public ActionResult Agregar(Invitado nuevoInvitado)
        {
            GestorInvitado gi = new GestorInvitado();
            gi.AltaInvitado(nuevoInvitado);
            ViewBag.cboPareja = new SelectList(gi.cboPareja(), "idP", "nombre1", nuevoInvitado.IdP);
            ViewBag.cboTipoRelacion = new SelectList(gi.cboTipoRelacion(), "idTR", "nombreTR", nuevoInvitado.IdTR);
            return View("Index");
        }
        public ActionResult Eliminar()
        {
            Invitado I = new Invitado();
            return View(I);
        }

        [HttpPost]
        public ActionResult Eliminar(Invitado borrarInvitado)
        {
            GestorInvitado gi = new GestorInvitado();
            gi.bajaInvitado(borrarInvitado);
            return View("Index");
        }
        public ActionResult Modificar()
        {
            Invitado I = new Invitado();
            GestorInvitado gi = new GestorInvitado();
            ViewBag.cboPareja = new SelectList(gi.cboPareja(), "idP", "nombre1");
            ViewBag.cboTipoRelacion = new SelectList(gi.cboTipoRelacion(), "idTR", "nombreTR");
            return View(I);
        }

        [HttpPost]
        public ActionResult Modificar(Invitado cambiarInvitado)
        {
            GestorInvitado gi = new GestorInvitado();
            gi.modificarInvitado(cambiarInvitado);
            ViewBag.cboPareja = new SelectList(gi.cboPareja(), "idP", "nombre1", cambiarInvitado.IdP);
            ViewBag.cboTipoRelacion = new SelectList(gi.cboTipoRelacion(), "idTR", "nombreTR", cambiarInvitado.IdTR);
            return View("Index");
        }
        public ActionResult Listar()
        {
            GestorInvitado GI = new GestorInvitado();
            List<InvitadoParejaDto> lista = GI.Listar();
            return View(lista);
        }
    }
}