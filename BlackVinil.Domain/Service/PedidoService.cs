using BlackVinil.Domain.Entities;
using BlackVinil.Domain.Interfaces.Repository;
using BlackVinil.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace BlackVinil.Domain.Service
{
    public class PedidoService : ServiceBase<Pedido>, IPedidoService
    {
        private readonly IPedidoRepository _repository;
        public PedidoService(IPedidoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public void Add(string discos)
        {
            _repository.Add(discos);
        }

        public IEnumerable<Pedido> GetByDate(DateTime dtIni, DateTime dtFim)
        {
           return  _repository.GetByDate(dtIni, dtFim);
        }
    }
}
