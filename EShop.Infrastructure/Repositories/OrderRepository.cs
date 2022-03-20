namespace EShop.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(EShopDbContext dbContext) : base(dbContext)
        {
        }

        public IUnitOfWork UnitOfWork => dbContext;
        public Order Add(Order order)
        {
            if (order.IsTransient())
            {
                return dbContext.Orders.Add(order).Entity;
            }

            return null;
        }

        public async Task<List<Order>> GetOrders(int customerId)
        {
            return await dbContext
                .Orders
                .Include(f => f.OrderItems)
                .Where(f => f.CustomerId == customerId)
                .ToListAsync();
        }
    }
}
