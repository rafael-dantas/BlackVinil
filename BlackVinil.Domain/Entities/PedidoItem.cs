using System;
using System.Collections.Generic;
using System.Text;

namespace BlackVinil.Domain.Entities
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }       
        public string IdDisco {get; set;}
        public virtual Disco Disco { get; set; }
        public double Valor { get; set; }
        public double CashBack { get; set; }
    }
}
