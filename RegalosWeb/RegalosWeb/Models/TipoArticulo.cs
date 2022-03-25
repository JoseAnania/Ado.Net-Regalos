using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class TipoArticulo
    {
        public int IdTA { get; set; }
        public string DenominacionTA { get; set; }

        public TipoArticulo(int idTA, string denominacionTA)
        {
            IdTA = idTA;
            DenominacionTA = denominacionTA;
        }

        public TipoArticulo()
        {
        }
    }
}