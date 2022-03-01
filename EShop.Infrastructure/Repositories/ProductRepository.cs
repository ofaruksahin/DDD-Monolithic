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

        public async Task<Product> GetProductById(int id)
        {
            Product product = null;
            product = await dbContext
                .Products
                .Include(f => f.Categories)
                .Include(f => f.Status)
                .Include(f => f.Attributes)
                .FirstOrDefaultAsync(f => f.Id == id);
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await dbContext
                .Products
                .Include(f => f.Categories)
                .Include(f => f.Status)
                .Include(f => f.Attributes)
                .ToListAsync();
        }

        public Product Update(Product product)
        {
            return dbContext.Products.Update(product).Entity;
        }
    }
}

