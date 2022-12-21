using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using OData.WithVersions.Models;

namespace OData.WithVersions
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
            services.AddControllers().AddOData(options => {
                options
                .AddRouteComponents("odata", GetEdmModel())  // this is important for odata-weather-forecast(1)
                       .Select()
                       .Filter()
                       .OrderBy()
                       .SetMaxTop(null)
                       .Count()
                       .Expand();
                options.EnableQueryFeatures();
                options.EnableAttributeRouting = true;
    });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddODataQueryFilter();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger();
            });

        }
        static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            var oDataWeatherForecast = builder.EntitySet<ODataWeatherForecast>("ODataWeatherForecast");
            return builder.GetEdmModel();
        }
    }
}

