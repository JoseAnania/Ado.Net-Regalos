using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class Comercio
    {
        public int IdC { get; set; }
        public string DenominacionC { get; set; }

        public Comercio(int idC, string denominacionC)
        {
            IdC = idC;
            DenominacionC = denominacionC;
        }

        public Comercio()
        {
        }
    }
}