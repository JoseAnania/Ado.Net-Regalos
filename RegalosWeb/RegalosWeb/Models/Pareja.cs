using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class Pareja
    {
        public int IdP { get; set; }
        public string Nombre1 { get; set; }
        public string Apellido1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido2 { get; set; }
        public string FechaCasamiento { get; set; }//en BD DATE
        public int IdC { get; set; }

        public Pareja(int idP, string nombre1, string apellido1, string nombre2, string apellido2, string fechaCasamiento, int idC)
        {
            IdP = idP;
            Nombre1 = nombre1;
            Apellido1 = apellido1;
            Nombre2 = nombre2;
            Apellido2 = apellido2;
            FechaCasamiento = fechaCasamiento;
            IdC = idC;
        }

        public Pareja()
        {
        }
    }
}