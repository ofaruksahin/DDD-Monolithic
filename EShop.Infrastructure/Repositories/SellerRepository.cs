namespace EShop.Infrastructure.Repositories
{
    public class SellerRepository : BaseRepository, ISellerRepository
    {
        public SellerRepository(EShopDbContext dbContext) : base(dbContext)
        {
        }

        public IUnitOfWork UnitOfWork => dbContext;

        public Seller Add(Seller seller)
        {
            if (seller.IsTransient())
            {
                return dbContext.Sellers.Add(seller).Entity;
            }
            return null;
        }

        public async Task<Seller> GetSeller(int sellerId)
        {
            return await dbContext
                .Sellers
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == sellerId);
        }

        public async Task<Seller> GetSellerByName(string name)
        {
            return await dbContext
                .Sellers
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Name == name);
        }

        public async Task<List<Seller>> GetSellers()
        {
            return await dbContext
                .Sellers
                .AsNoTracking()
                .ToListAsync();
        }

        public Seller Update(Seller seller)
        {
            return dbContext.Sellers.Update(seller).Entity;
        }
    }
}

