using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class Usuario
    {
        public int IdU { get; set; }
        public string NombreU { get; set; }
        public string Contrasenia { get; set; }

        public Usuario(int idU, string nombreU, string contrasenia)
        {
            IdU = idU;
            NombreU = nombreU;
            Contrasenia = contrasenia;
        }

        public Usuario()
        {
        }
    }
}