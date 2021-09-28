using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDemo.Services;
using EmployeeDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddSingleton<IFormatNumber,FormatNumber>();
            services.AddScoped<IEmployeeRepository, DBRepository>();
            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=PCAD2EmployeeDB;Trusted_Connection=True;MultipleActiveResultSets=true"));
            /*services.AddScoped<IEmployeeRepository, DBRepository>();
            services.AddDbContext<EmployeeContext>(options => options.UseSqlite("Data Source=employee.db"));*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EmployeeContext employeeContext)
        {

            employeeContext.Database.EnsureDeleted();
            employeeContext.Database.EnsureCreated();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
