using CoreLayer;
using DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer;
using CoreLayer.Services;
using Microsoft.OpenApi.Models;
using AutoMapper;
using System.IO;

namespace PosTerminalApi
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
            services.AddControllers();
            services.AddDbContext<TerminalDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("DataLayer")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pos Terminal API", Version = "v1" });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "PosTerminalApi.xml");
                c.IncludeXmlComments(filePath);

            });
            services.AddAutoMapper(typeof(Startup));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger(); 
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api/swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pos Terminal API v1");
            });
        }
    }
}
