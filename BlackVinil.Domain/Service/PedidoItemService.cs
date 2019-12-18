using BlackVinil.Domain.Entities;
using BlackVinil.Domain.Interfaces.Repository;
using BlackVinil.Domain.Interfaces.Service;

namespace BlackVinil.Domain.Service
{
    public class PedidoItemService : ServiceBase<PedidoItem>, IPedidoItemService
    {
        private readonly IPedidoItemRepository _repository;

        public PedidoItemService(IPedidoItemRepository repository)
            :base(repository)
        {
            _repository = repository;
        }
    }
}
