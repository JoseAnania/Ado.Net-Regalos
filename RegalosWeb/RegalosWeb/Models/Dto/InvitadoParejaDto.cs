using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class InvitadoParejaDto
    {
        public int IdI { get; set; }
        public string NombreI { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string NombreTR { get; set; }

        public InvitadoParejaDto(int idI, string nombreI, string nombre1, string nombre2, string nombreTR)
        {
            IdI = idI;
            NombreI = nombreI;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            NombreTR = nombreTR;
        }

        public InvitadoParejaDto()
        {
        }
    }
}