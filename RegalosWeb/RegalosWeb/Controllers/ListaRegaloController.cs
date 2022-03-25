using RegalosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegalosWeb.Controllers
{
    public class ListaRegaloController : Controller
    {
        // GET: ListaRegalo
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ListaRegalo()
        {
            string idP = Request.Params["idP"];
            int numeroP = Convert.ToInt32(idP);
            GestorRegalo gr = new GestorRegalo();
            GestorPareja gp = new GestorPareja();
            List<RegaloDto> lista = gr.Listar(gp.numeroPareja(numeroP));
            return View(lista);
        }
    }
}