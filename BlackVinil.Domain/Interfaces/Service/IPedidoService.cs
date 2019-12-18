using BlackVinil.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BlackVinil.Domain.Interfaces.Service
{
    public interface IPedidoService : IServiceBase<Pedido>
    {
        void Add(string discos);
        Pedido GetById(int id);
        IEnumerable<Pedido> GetByDate(DateTime dtIni, DateTime dtFim);
    }
}
