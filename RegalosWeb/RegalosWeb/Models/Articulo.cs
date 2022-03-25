using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class Articulo
    {
        public int IdA { get; set; }
        public string codigoA { get; set; }
        public string DenominacionA { get; set; }
        public float PrecioUnitario { get; set; }
        public int IdTA { get; set; }

        public Articulo(int idA, string codigoA, string denominacionA, float precioUnitario, int idTA)
        {
            IdA = idA;
            this.codigoA = codigoA;
            DenominacionA = denominacionA;
            PrecioUnitario = precioUnitario;
            IdTA = idTA;
        }

        public Articulo()
        {
        }
    }
}