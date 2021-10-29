using AcademyG.Week8.Core;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestWeek8.Core.Interfaces;
using TestWeek8.EF;
using TestWeek8.EF.Repository;

namespace TestWeek8
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
            services.AddControllersWithViews();
            services.AddControllersWithViews(
            //configurazione globale del filtro
            //options => options.Filters.Add(new LogFilterAttribute())
            );
            services.AddTransient<IMainBusinessLayer, MainBusinessLayer>();
            services.AddTransient<IRepositoryMenu, RepositoryMenuEF>();
            services.AddTransient<IRepositoryPlate, RepositoryPlateEF>();
            services.AddTransient<IRepositoryUser, RepositoryUserEF>();

            services.AddDbContext<MenuContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MenuDB"));
            });

            //AGGIUNGIAMO FILTRO DI AUTENTICAZIONE
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                    options =>
                    {
                        options.LoginPath = new PathString("/User/Login");
                        options.AccessDeniedPath = new PathString("/User/Forbidden");
                    }
                );

            //FILTRO DI AUTORIZZAZIONE
            services.AddAuthorization(
                options =>
                {
                    options.AddPolicy("AdministratorUser", policy => policy.RequireRole("Administrator"));
                    options.AddPolicy("SimpleUser", policy => policy.RequireRole("User"));
                }
            );
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
