using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RestaurantOrder.Domain.Interfaces.Repositories;
using RestaurantOrder.Domain.Interfaces.Services;
using RestaurantOrder.Infra.Respositories;
using RestaurantOrder.Infra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrder.WebApi.Configuration
{
    public static class ServicesConfiguration
    {
        public static void AddSwaggerServices(this IServiceCollection services)
        {
            var ver = typeof(Startup).Assembly.GetName().Version.ToString();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Restaurant Order Api",
                        Version = "v1",
                        Description = "Build: " + ver,
                        Contact = new OpenApiContact
                        {
                            Name = "RestaurantOrderApi",
                        }
                    });
            });
        }

        public static void AddScopedClasses(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryOrder, OrderRepository>();
            services.AddScoped<IServiceOrder, OrderService>();
        }
    }
}
