using BlackVinil.Application;
using BlackVinil.Application.Interfaces;
using BlackVinil.Domain.Interfaces.Repository;
using BlackVinil.Domain.Interfaces.Service;
using BlackVinil.Domain.Service;
using BlackVinil.Infra.Data.Repository;
using System;

namespace BlackVinil.IoC
{
    public class ModuleInject
    {
        public static AppDiscoService Load(IAppDiscoService inter) { return new AppDiscoService(new DiscoService(new DiscoRepository())); }
        public static AppPedidoService Load(IAppPedidoService inter) { return new AppPedidoService(new PedidoService(new PedidoRepository())); }
        public static AppPedidoItemService Load(IAppPedidoItemService inter) { return new AppPedidoItemService(new PedidoItemService(new PedidoItemRepository())); }        

    }
}
