using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PomagajLokalnieApp.MapperProfiles;
using Services.Admin;
using Services.Anonymous;
using Services.Client;
using Services.Company;

namespace PomagajLokalnieApp
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
            
            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Admin");
                    options.Conventions.AuthorizeFolder("/Company");
                })
                .AddRazorRuntimeCompilation();
            
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer("Server=localhost;Database=PomagajDb;Trusted_Connection=True;");
            });
            
            services.AddAutoMapper(x => x.AddProfiles(new List<Profile>()
                {
                    new MapperProfiles.MapperProfiles()
                }
            ), typeof(Startup));
            
            services.AddScoped<IBusinessmanService, BusinessmanService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IAnonymousService, AnonymousService>();
            services.AddScoped<IAppDbContext, AppDbContext>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}