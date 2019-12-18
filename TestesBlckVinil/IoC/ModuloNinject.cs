using BlackVinil.Application;
using BlackVinil.Application.Interfaces;
using BlackVinil.Domain.Interfaces.Service;
using BlackVinil.Domain.Service;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using Ninject;
using Ninject.Modules;

namespace TestesBlckVinil.IoC
{
    public class ModuloNinject : NinjectModule
    {
        public override void Load()
        {
            // Domain
            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IPedidoService>().To<PedidoService>();
            Bind<IPedidoItemService>().To<PedidoItemService>();
            Bind<IDiscoService>().To<DiscoService>();

            // Application
            Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            Bind<IAppPedidoService>().To<AppPedidoService>();
            Bind<IAppPedidoItemService>().To<AppPedidoItemService>();
            Bind<IAppDiscoService>().To<AppDiscoService>();
        }

        public static ModuloNinject Create()
        {
            return new ModuloNinject();
        }
    }


    public class FormResolve
    {
        private static IKernel _ninjectKernel;

        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
    }
}
