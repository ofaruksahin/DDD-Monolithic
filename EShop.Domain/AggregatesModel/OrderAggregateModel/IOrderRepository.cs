namespace EShop.Domain.AggregatesModel.OrderAggregateModel
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order Add(Order order);
        Task<List<Order>> GetOrders(int customerId);
    }
}
