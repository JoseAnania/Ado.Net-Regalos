﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegalosWeb.Controllers
{
    public class MensajeController : Controller
    {
        // GET: Mensaje
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}