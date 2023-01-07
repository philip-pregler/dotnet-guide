using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Routing.Conventions;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using OData.Basic.Models;

namespace OData.Basic
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
            services
                .AddControllers()
                .AddOData(options =>
                {
                    // delete unnecessary conventions
                    options.Conventions.Clear();
                    options.Conventions.Add(new MetadataRoutingConvention());
                    options.Conventions.Add(new EntitySetRoutingConvention());
                    options.Conventions.Add(new ActionRoutingConvention());
                    options
                        .AddRouteComponents("odata", GetEdmModel()) // this is important for odata-weather-forecast(1)
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
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<ODataQueryOptionOperationFilter>();
                // c.ResolveConflictingActions (apiDescriptions => apiDescriptions.First ());
            });
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
                endpoints.MapSwagger("/swagger/{documentName}/swagger.json");
            });

        }
        static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<ODataWeatherForecast>("ODataWeatherForecast");
            return builder.GetEdmModel();
        }
    }
}

