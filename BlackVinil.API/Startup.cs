using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackVinil.API.Controllers;
using BlackVinil.Application;
using BlackVinil.Application.Interfaces;
using BlackVinil.Domain.Interfaces.Repository;
using BlackVinil.Domain.Interfaces.Service;
using BlackVinil.Domain.Service;
using BlackVinil.Infra.Data.Repository;
using BlackVinil.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BlackVinil.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Application 
            services.AddTransient<IAppDiscoService, AppDiscoService>();
            services.AddTransient<IAppPedidoService, AppPedidoService>();
            services.AddTransient<IAppPedidoItemService, AppPedidoItemService>();
            //services.AddTransient(typeof(IAppServiceBase<>),typeof(AppServiceBase<>));

            // Domain
            services.AddTransient<IDiscoService, DiscoService>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IPedidoItemService, PedidoItemService>();
            //services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));

            // Infra
            services.AddTransient<IDiscoRepository, DiscoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IPedidoItemRepository, PedidoItemRepository>();
            //services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();
        }
    }
}
