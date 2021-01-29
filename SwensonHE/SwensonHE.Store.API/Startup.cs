using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SwensonHE.Store.DatabaseContext;
using SwensonHE.Store.Ground;
using Microsoft.EntityFrameworkCore;
using SwensonHE.Store.Service.Interfaces;
using SwensonHE.Store.Service.Implementation;
using System;
using SwensonHE.Store.Presistance.CoreImplementation.Repositories;

namespace SwensonHE.Store.API
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
            services.AddHttpClient();

            services.AddScoped<DbContext, StoreDBEntities>();
            services.AddDbContext<IStoreDBEntities, StoreDBEntities>(Db => Db.UseSqlServer(Configuration.GetConnectionString("CoffeStoreConnectionString")));
            services.AddTransient<IItemSKUServices, ItemSKUService>();
            services.AddTransient(provider => new Lazy<IItemSKUServices>(provider.GetService<IItemSKUServices>));

            services.AddTransient<IItemSKUServiceValidator, ItemSKUServiceValidator>();
            services.AddTransient(provider => new Lazy<IItemSKUServiceValidator>(provider.GetService<IItemSKUServiceValidator>));
           
            services.AddTransient<IItemSKURepository, ItemSKURepository>();
            services.AddTransient(provider => new Lazy<IItemSKURepository>(provider.GetService<IItemSKURepository>));


            services.AddTransient<IItemSKUValidator, ItemSKUValidator>();
            services.AddTransient(provider => new Lazy<IItemSKUValidator>(provider.GetService<IItemSKUValidator>));



            services.AddControllers();
            //  
            //services.AddTransient<IItemSKUServices, ItemSKUService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            dbContext.Database.EnsureCreated();

        }
    }
}
