using Catalog.Core.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddCatalogService(this IServiceCollection services,
                                                           IConfiguration configuration)
        {

            services.AddMediatR(opt =>
            {
                opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            
            
            return services;
        }
    }
}
