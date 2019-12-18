using System;
using System.Collections.Generic;
using System.Text;

namespace BlackVinil.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public virtual IList<PedidoItem> Item { get; set; }
        public double Total { get; set; }
        public double TotalCashBack { get; set; }

    }
}
