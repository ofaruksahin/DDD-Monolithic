namespace EShop.API.Extensions
{
    internal static class DIExtensions
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationAssemblyLoader));
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}

