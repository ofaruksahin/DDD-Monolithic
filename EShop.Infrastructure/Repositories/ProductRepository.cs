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
                return dbContext.Products.Add(product).Entity;
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
                .Include(f => f.Attributes)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await dbContext
                .Products
                .Include(f => f.Categories)
                .Include(f => f.Attributes)
                .AsNoTracking()
                .ToListAsync();
        }

        public Product Update(Product product)
        {
            return dbContext.Products.Update(product).Entity;
        }

        public ProductAttribute UpdateAttribute(ProductAttribute productAttribute)
        {
            return dbContext.ProductAttributes.Update(productAttribute).Entity;
        }

        public ProductCategory UpdateCategory(ProductCategory productCategory)
        {
            return dbContext.ProductCategories.Update(productCategory).Entity;
        }

        public async Task<List<Product>> GetProductsBySeller(int sellerId)
        {
            return await dbContext
                   .Products
                   .Where(f => f.StatusId == EnumStatus.Active.Id)
                   .ToListAsync();
        }
    }
}

