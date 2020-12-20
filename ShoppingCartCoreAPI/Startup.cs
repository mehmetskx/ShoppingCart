using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingCart.Business.Derived;
using ShoppingCart.Business.Infrastructure;
using ShoppingCart.Data;
using ShoppingCart.Data.Derived;
using ShoppingCart.Data.Infrastructure;
using ShoppingCart.Helper.DTOModels;
using ShoppingCart.Helper.Infrastructure;
using ShoppingCart.Helper.Log;
using ShoppingCart.Helper.Middleware;
using ShoppingCart.Helper.Validation.Fluent;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Derived.EFRepository;
using ShoppingCart.Helper.Mapping;

namespace ShoppingCartCoreAPI
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
            services.AddTransient<ICartManager, CartManager>();

            services.AddControllers().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

            services.AddDbContext<ShoppingCartDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<ILoggerManager, TextLoggerManager>();
            services.AddAutoMapper(typeof(EntityToModel));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            RepositoryConfigureService(services);
            ValidatorConfigureService(services);
         
        }
        //This method created for readability
        public void ValidatorConfigureService(IServiceCollection services)
        {
            services.AddSingleton<IValidator<ProductDTO>, ProductDTOValidator>();            
        }

        //This method created for readability
        public void RepositoryConfigureService(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
