using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using SharpGamingAPI.Common.Exceptions;
using SharpGamingAPI.Common.Configuration;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SharpGamingAPI
{
	public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            DBConfig.Connection = _configuration.GetConnectionString("DefaultConnection");           
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers();
            // ==============================================
            // Register the Swagger generator, defining 1 or more Swagger documents
            // ==============================================
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sharp Gaming API", Version = "V1", Description = "A simple example of SharpGaming API" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            RegisterExceptionHandler.ExceptionHandler(app);
            // ==============================================
            // To enable Routing
            // ==============================================
            app.UseRouting();

            // ==============================================
            // To enable Authentication   
            // ==============================================
            app.UseAuthentication();
            app.UseAuthorization();

            // ==============================================  
            // To enable middleware to serve generated Swagger as a JSON endpoint.
            // ==============================================
            app.UseSwagger();
            // ==============================================
            // To enable middleware to serve swagger-ui (HTML, JS, CSS), specifying the Swagger JSON endpoint
            // ==============================================
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sharp Gaming API Endpoint");
                c.DocumentTitle = "Sharp Gaming API";
                c.DocExpansion(DocExpansion.None);
                c.DefaultModelsExpandDepth(-1);
            });
            // ==============================================
            // To enable Endpoints   
            // ==============================================
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}