using EShop.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EShop.API.Extensions
{
    internal static class DbContextExtension
    {
        public static void AddShopDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EShopDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("MySQLConnectionString");
                options.UseMySql(connectionString, new MySqlServerVersion(MySqlServerVersion.AutoDetect(connectionString)));

            });
        }
    }
}

