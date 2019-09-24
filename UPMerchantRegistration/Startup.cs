using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using UPMerchantRegistration.Areas.Identity.Services;
using System.IO;

namespace UPMerchantRegistration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //env
        public IHostingEnvironment hostingEnvironment { get; }

        //end env
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //cookie policy
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //db context
            var connectionString = Configuration.GetConnectionString("DataAccessPostgreSqlProvider");
            services.AddEntityFrameworkNpgsql().AddDbContext<UPAGENTMANAGERContext>(options =>
                options.UseNpgsql(connectionString));

            //identity


            //Identity Options

            //iis
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            //env

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //WebRootPath == null workaround.
            if (string.IsNullOrWhiteSpace(env.WebRootPath))
                env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //enable authentication
            app.UseAuthentication();
            //app.UseHttpsRedirection();
        }
    }
}
