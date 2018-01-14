using System;
using ASPCoreApp.Core.Interfaces;
using ASPCoreApp.Core.SharedKernel;
using ASPCoreApp.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace ASPCoreApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            string dbName = Guid.NewGuid().ToString();
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase(dbName));
                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc()
                .AddControllersAsServices();

            var container = new Container();

            container.Configure(config =>
            {
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Startup));
                    _.AssemblyContainingType(typeof(BaseEntity));
                    _.Assembly("ASPCoreApp.Infrastructure");
                    _.WithDefaultConventions();
                    _.ConnectImplementationsToTypesClosing(typeof(IHandle<>));
                });
                
                config.For(typeof(IRepository<>)).Add(typeof(EfRepository<>));
                
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedData.PopulateTestData(app.ApplicationServices.GetService<AppDbContext>());
        }
    }
}
