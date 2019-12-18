using BlackVinil.Domain.Entities;
using BlackVinil.Application.Interfaces;
using BlackVinil.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace BlackVinil.Application
{
    public class AppPedidoService : AppServiceBase<Pedido>, IAppPedidoService
    {
        private readonly IPedidoService _service;
        public AppPedidoService(IPedidoService service)
            : base(service)
        {
            _service = service;
        }

        public void Add(string discos)
        {
            _service.Add(discos);
        }

        public Pedido GetById(int id)
        {
            return _service.GetById(id);
        }

        public IEnumerable<Pedido> GetByDate(DateTime dtIni, DateTime dtFim)
        {
            return _service.GetByDate(dtIni, dtFim);
        }
    }
}
