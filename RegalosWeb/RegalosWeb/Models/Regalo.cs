using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class Regalo
    {
        public int IdR { get; set; }
        public int IdP { get; set; }
        public int IdA { get; set; }
        public int IdI { get; set; }
        public int Cantidad { get; set; }
        public int Regalado { get; set; }

        public Regalo(int idR, int idP, int idA, int idI, int cantidad, int regalado)
        {
            IdR = idR;
            IdP = idP;
            IdA = idA;
            IdI = idI;
            Cantidad = cantidad;
            Regalado = regalado;
        }

        public Regalo()
        {
        }
    }
}