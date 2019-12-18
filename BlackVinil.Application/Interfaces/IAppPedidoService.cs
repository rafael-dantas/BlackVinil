using BlackVinil.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BlackVinil.Application.Interfaces
{ 
    public interface IAppPedidoService : IAppServiceBase<Pedido>
    {
        void Add(string discos);

        Pedido GetById(int id);
        IEnumerable<Pedido> GetByDate(DateTime dtIni, DateTime dtFim);
    }
}
