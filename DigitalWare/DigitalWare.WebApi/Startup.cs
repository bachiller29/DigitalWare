using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalWare.Business.Interfaces.Repositories;
using DigitalWare.Business.Interfaces.Services;
using DigitalWare.Business.Services;
using DigitalWare.Data;
using DigitalWare.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DigitalWare.WebApi
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
            //Contexto y conecion a la Db
            services.AddDbContext<BillingContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BillingConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped(typeof(IProductsService), typeof(ProductsServices));
            services.AddScoped(typeof(IProductsRepository), typeof(ProductsRepository));

            services.AddScoped(typeof(ISalesService), typeof(SalesServices));
            services.AddScoped(typeof(ISalesRepository), typeof(SalesRepository));

            services.AddScoped(typeof(IClientService), typeof(ClientServices));
            services.AddScoped(typeof(IClientRepository), typeof(ClientRepository));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
