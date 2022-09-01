using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Proj_Mercado_Seguros.src.Models
{
    public class Contrato
    {
        public Contrato()
        {
            this.DataCriacao = DateTime.Now;
            this.Valor = 0;
            this.IdToken = "0000";
            this.Pago = false;
        }

        public Contrato(double Valor, string IdToken)
        {
            this.DataCriacao = DateTime.Now;
            this.Valor = Valor;
            this.IdToken = IdToken;
            this.Pago = false;
        }
        public DateTime DataCriacao { get; set; }
        public string IdToken { get; set; }
        public double Valor { get; set; }
        public bool Pago { get; set; }
    }
}