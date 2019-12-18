using BlackVinil.Domain.Entities;
using BlackVinil.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace BlackVinil.Domain.Interfaces.Repository
{
    public interface IPedidoRepository : IRepositoryBase<Pedido>
    {
        void Add(string discos);
        Pedido GetById(int id);
        IEnumerable<Pedido> GetByDate(DateTime dtIni, DateTime dtFim);
    }
}
