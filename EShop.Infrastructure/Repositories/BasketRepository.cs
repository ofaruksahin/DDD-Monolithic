namespace EShop.Infrastructure.Repositories
{
    public class BasketRepository : BaseRepository, IBasketRepository
    {
        public BasketRepository(EShopDbContext dbContext) : base(dbContext)
        {
        }

        public IUnitOfWork UnitOfWork => dbContext;

        public Basket Add(Basket basket)
        {
            if (basket.IsTransient())
            {
                return dbContext.Baskets.Add(basket).Entity;
            }
            return null;
        }

        public async Task<Basket> GetBasketByCustomerId(int customerId)
        {
            return await dbContext
                .Baskets
                .Include(f => f.BasketItems)
                .Where(f => f.StatusId == EnumStatus.Active.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public Basket Update(Basket basket)
        {
            return dbContext.Baskets.Update(basket).Entity;
        }

        public BasketItem Update(BasketItem basketItem)
        {
            return dbContext.BasketItems.Update(basketItem).Entity;
        }
    }
}

