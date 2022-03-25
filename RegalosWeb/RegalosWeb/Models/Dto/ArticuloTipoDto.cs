using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class ArticuloTipoDto
    {
        public int IdA { get; set; }
        public string codigoA { get; set; }
        public string DenominacionA { get; set; }
        public float PrecioUnitario { get; set; }
        public string DenominacionTA { get; set; }

        public ArticuloTipoDto(int idA, string codigoA, string denominacionA, float precioUnitario, string denominacionTA)
        {
            IdA = idA;
            this.codigoA = codigoA;
            DenominacionA = denominacionA;
            PrecioUnitario = precioUnitario;
            DenominacionTA = denominacionTA;
        }

        public ArticuloTipoDto()
        {
        }
    }
}