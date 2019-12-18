using BlackVinil.Domain.Entities;
using BlackVinil.Application.Interfaces;
using BlackVinil.Domain.Interfaces.Service;

namespace BlackVinil.Application
{
    public class AppPedidoItemService : AppServiceBase<PedidoItem>, IAppPedidoItemService
    {
        private readonly IPedidoItemService _service;

        public AppPedidoItemService(IPedidoItemService service)
            :base(service)
        {
            _service = service;
        }
    }
}
