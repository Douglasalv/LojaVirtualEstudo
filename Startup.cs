using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LojaVirtual.Database;
using Microsoft.EntityFrameworkCore;
using LojaVirtual.Models.Repositories.Contracts;
using LojaVirtual.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Libraries.Session;
using LojaVirtual.Libraries.Login;

namespace LojaVirtual
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            /*
             * Padrão repository sendo utilizado
             */
            services.AddHttpContextAccessor();
            services.AddScoped<INewsletterRepository, NewsletterRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            /*
             * Session - Configuração
             */
            services.AddMemoryCache(); //guardar dados na memória
            services.AddSession(options =>
            {
             
            }
            );

            services.AddScoped<Session>();
            services.AddScoped<LoginCliente>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllersWithViews();
            services.AddDbContext<LojaVirtualContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
