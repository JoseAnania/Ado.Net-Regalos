using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class RegaloDto
    {
        public int IdR { get; set; }
        public string DenominacionA { get; set; }
        public int IdA { get; set; }
        public int IdP { get; set; }
        public int Regalado { get; set; }

        public RegaloDto(int idR, string denominacionA, int idA, int idP, int regalado)
        {
            IdR = idR;
            DenominacionA = denominacionA;
            IdA = idA;
            IdP = idP;
            Regalado = regalado;
        }

        public RegaloDto()
        {
        }
    }
}