namespace EShop.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(EShopDbContext dbContext) : base(dbContext)
        {
        }

        public IUnitOfWork UnitOfWork => dbContext;

        public Product Add(Product product)
        {
            if (product.IsTransient())
            {
                return dbContext.Add(product).Entity;
            }
            else
            {
                return product;
            }
        }
    }
}

