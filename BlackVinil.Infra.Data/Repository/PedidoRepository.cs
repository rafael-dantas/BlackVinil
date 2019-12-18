using System;
using System.Collections.Generic;
using System.Linq;
using BlackVinil.Domain.Entities;
using BlackVinil.Domain.Interfaces.Repository;

namespace BlackVinil.Infra.Data.Repository
{
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        public void Add(string discos)
        {
            Pedido pedido = new Pedido();
            List<string> lstDiscos = discos.Split(';').ToList();
           
            List<PedidoItem> lstPedidoItem = new List<PedidoItem>();

            Db.Set<Pedido>().Add(pedido);
            Db.SaveChanges();
            int idPedido = pedido.Id;

            double t = 0;
            double tc = 0;
            foreach (string id in lstDiscos)
            {
                Disco di = Db.Set<Disco>().Find(id);
                PedidoItem pedidoItem = new PedidoItem();

                pedidoItem.Valor = CashBack.Preco(di.Genero);
                pedidoItem.CashBack = CashBack.Calcular(di.Genero);
                pedidoItem.IdDisco = di.Id;
                pedidoItem.IdPedido = idPedido;

                t += di.Preco;
                tc += pedidoItem.CashBack;
                lstPedidoItem.Add(pedidoItem);
            }

            pedido.Total = t;
            pedido.TotalCashBack = tc;
            pedido.DataPedido = DateTime.Now;

            Db.Entry(pedido).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Db.SaveChanges();
           
            
            Db.Set<PedidoItem>().AddRange(lstPedidoItem);
            Db.SaveChanges();
        }

        public override Pedido GetById(int id)
        {
            Pedido pedido = Db.Set<Pedido>().Find(id);

            IEnumerable<PedidoItem> lst = Db.Set<PedidoItem>().Where(x => x.IdPedido == id).ToList();
            pedido.Item = lst.ToList();

            return pedido;
        }

        public IEnumerable<Pedido> GetByDate(DateTime dtIni, DateTime dtFim)
        {
            if (dtIni > dtFim)
                throw new Exception("Data Fim não pode ser menor que a data inicio");

            List<Pedido> pedidos = Db.Set<Pedido>().Where(x => x.DataPedido >= dtIni && x.DataPedido <= dtFim).OrderByDescending(x => x.DataPedido).ToList();

            int cont = 0;
            foreach(Pedido p in pedidos)
            {
                List<PedidoItem> lst = Db.Set<PedidoItem>().Where(x => x.IdPedido == p.Id).ToList();
                pedidos[cont].Item = lst;

                cont++;
            }
            
            return pedidos;
        }
    }
}
