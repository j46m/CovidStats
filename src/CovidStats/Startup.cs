using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using CovidStats.data.DTO;
using CovidStats.data.Implementations;
using CovidStats.data.Interfaces;
using CovidStats.logic.Files.Implementations;
using CovidStats.logic.Files.Interfaces;
using CovidStats.logic.Reports.Implementations;
using CovidStats.logic.Reports.Interfaces;

namespace CovidStats
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
            var reportConfig = new ReportConfig
            {
                Url = "https://covid-19-statistics.p.rapidapi.com/reports",
                ApiKey = "48c6ea5926msh35c92edffc8d551p130b01jsnb7aafad496a2",
                ApiHost = "covid-19-statistics.p.rapidapi.com",
            };

            services.AddHttpClient();
            services.AddScoped<IReportRetriever>(x => new ReportRetriever(reportConfig,x.GetRequiredService<IHttpClientFactory>()));
            services.AddScoped<IReportBuilder>(x => new ReportBuilder(x.GetRequiredService<IReportRetriever>()));

            services.AddSingleton<ISerializer, JsonSerializer>(); //TODO: Factory to return XmlSerializer 
            services.AddScoped<IFileSaver, FileSaver>();
            services.AddScoped<IFileGetter, FileGetter>();

            services.AddControllersWithViews();
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
