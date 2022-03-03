namespace EShop.Infrastructure.Repositories
{
    public class BasketRepository : BaseRepository, IBasketRepository
    {
        public BasketRepository(EShopDbContext dbContext) : base(dbContext)
        {
        }

        public IUnitOfWork UnitOfWork => dbContext;
    }
}

