using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class Invitado
    {
        public int IdI { get; set; }
        public string NombreI { get; set; }
        public int IdP { get; set; }
        public int IdTR { get; set; }

        public Invitado(int idI, string nombreI, int idP, int idTR)
        {
            IdI = idI;
            NombreI = nombreI;
            IdP = idP;
            IdTR = idTR;
        }

        public Invitado()
        {
        }
    }
}