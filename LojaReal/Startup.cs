using AutoMapper;
using LojaReal.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.UnitOfWork.Abstract;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Service.Concrete;
using System.Reflection;

namespace LojaReal
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
            string connectionString = Configuration.GetConnectionString("Debug");

            _ = connectionString ?? throw new KeyNotFoundException("Connection string not found");

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddDbContext<LojaContext>(options =>
                options.UseMySQL(connectionString));

            services.AddTransient<ICategoriumService, CategoriumService>();
            services.AddTransient<ILojaService, LojaService>();
            services.AddTransient<IProdutoService, ProdutoService>();

            services.AddControllersWithViews();

            services.AddTransient<IUnitOfWork, DataAccess.UnitOfWork.Concrete.UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
