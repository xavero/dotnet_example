using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WeatherApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            a
                b
                c
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddOptions<SimulationConfig>()
                .Bind(Configuration.GetSection(nameof(SimulationConfig)))
                .ValidateDataAnnotations();

            services.AddTransient<IBreakApplicationService, BreakApplicationService>();
            services.AddTransient<ApplicationBrokenMiddleware>();
            services.AddTransient<ApplicationSlowedMiddleware>();

            services.AddControllers().AddMetrics();

            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ApplicationBrokenMiddleware>();
            app.UseMiddleware<ApplicationSlowedMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/healthz");
                endpoints.MapControllers();
            });
        }
    }
}
