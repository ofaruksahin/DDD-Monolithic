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
                dbContext.Entry(basket).State = EntityState.Added;
                foreach (var item in basket.BasketItems)
                {
                    dbContext.Entry(item).State = EntityState.Added;
                }
                return basket;
            }
            return basket;
        }

        public async Task<Basket> GetBasketByCustomerId(int customerId)
        {
            return await dbContext
                .Baskets
                .Include(f => f.Status)
                .Include(f => f.BasketItems)
                .Where(f => f.Status.Id == EnumStatus.Active.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public Basket Update(Basket basket)
        {
            dbContext.Entry(basket).State = EntityState.Modified;
            return basket;
        }

        public BasketItem Update(BasketItem basketItem)
        {
            dbContext.Entry(basketItem).State = EntityState.Modified;
            return basketItem;
        }
    }
}

