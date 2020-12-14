using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace StockService
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
            services.AddControllers();
            services.AddDbContext<Repository.Abstracts.IProductRepository, Repository.Implementations.EntityFrameworkProductRepository>(opt => opt.UseInMemoryDatabase("AvanadeStockService"))
                .AddScoped<Controllers.Converters.Abstracts.IFactory, Controllers.Converters.Implementations.ConverterFactory>()
                .AddScoped<Services.Abstracts.Converter.IModelJSONConverter, Services.Implementations.Converter.ModelJSONConverter>()
                .AddScoped<Services.Abstracts.Converter.IModelByteConverter, Services.Implementations.Converter.ModelByteConverter>()
                .AddScoped<Repository.Abstracts.IUnitOfWork, Repository.Implementations.UnitOfWork>()
                .AddScoped<Services.Abstracts.INotifyService, Services.Implementations.AzureServiceBusNotifyService>()
                .AddScoped<Services.Abstracts.IProductService, Services.Implementations.ProductService>()
                .AddScoped<Services.Abstracts.INotifiedService, Services.Implementations.AzureServiceBusNotifiedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Services.Abstracts.INotifiedService notified)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            notified.StartListen();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
