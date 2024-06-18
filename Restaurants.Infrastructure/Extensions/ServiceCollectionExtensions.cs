using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Repository;
using Restaurants.Infrastructure.Data;
using Restaurants.Infrastructure.Repository;
using Restaurants.Infrastructure.Seeders;
using Restaurnats.Domain.Entities___Copy;

namespace Restaurants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastruture(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionstring = configuration.GetConnectionString("RestaurantDb");
            services.AddDbContext<RestuarantDbContext>(options =>
            {
                options.UseSqlServer(connectionstring);
            });

            services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<RestuarantDbContext>();

            services.AddScoped<IRestuarantSeeders, RestuarantSeeders>();
            services.AddScoped<IRestuarantServices,RestuarantSercices>();
            services.AddScoped<IDisheServices,DishServices>();


            
        }

    }
}
