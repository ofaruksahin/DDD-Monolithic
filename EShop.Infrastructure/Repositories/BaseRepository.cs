namespace EShop.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        private EShopDbContext _dbContext;

        protected EShopDbContext dbContext
        {
            get => _dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            private set
            {
                _dbContext = value;
            }
        }

        public BaseRepository(EShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}

