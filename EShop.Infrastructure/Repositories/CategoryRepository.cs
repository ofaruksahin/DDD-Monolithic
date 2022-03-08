namespace EShop.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(EShopDbContext dbContext) : base(dbContext)
        {
        }

        public IUnitOfWork UnitOfWork => dbContext;

        public Category Add(Category category)
        {
            if (category.IsTransient())
            {
                return dbContext.Categories.Add(category).Entity;
            }
            return null;
        }

        public async Task<List<Category>> GetCategories()
        {
            return dbContext.Categories.AsNoTracking().ToList();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return dbContext.Categories.AsNoTracking().FirstOrDefault(f => f.Id == id);
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            return dbContext.Categories.AsNoTracking().FirstOrDefault(f => f.Name == name);
        }

        public Category Update(Category category)
        {
            return dbContext.Categories.Update(category).Entity;
        }
    }
}

