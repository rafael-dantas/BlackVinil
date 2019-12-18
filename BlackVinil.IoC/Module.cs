using Ninject;
using Ninject.Modules;
using BlackVinil.Application;
using BlackVinil.Domain.Service;
using BlackVinil.Application.Interfaces;
using BlackVinil.Domain.Interfaces.Service;
using BlackVinil.Domain.Interfaces.Repository;
using BlackVinil.Infra.Data.Repository;
using System.Reflection;

namespace BlackVinil.IoC
{
    public class Module : NinjectModule
    {
        //private static IDiscoRepository getInstance() { return new DiscoRepository(); }

        //public static IDiscoService getInstance() { return new DiscoService(getInstance()); }

        //public static T GetInstance(object obj)
        //{
        //    var retorno = new object();
        //    return
        //}

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

            // Infra
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind<IPedidoRepository>().To<PedidoRepository>();
            Bind<IPedidoItemRepository>().To<PedidoItemRepository>();
            Bind<IDiscoRepository>().To<DiscoRepository>();
        }

        public static Module Create()
        {
            return new Module();
        }
    }


    public class ModuleResolve
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