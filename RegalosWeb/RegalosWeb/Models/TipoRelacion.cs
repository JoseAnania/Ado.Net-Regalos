using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class TipoRelacion
    {
        public int IdTR { get; set; }
        public string NombreTR { get; set; }

        public TipoRelacion(int idTR, string nombreTR)
        {
            IdTR = idTR;
            NombreTR = nombreTR;
        }

        public TipoRelacion()
        {
        }
    }
}