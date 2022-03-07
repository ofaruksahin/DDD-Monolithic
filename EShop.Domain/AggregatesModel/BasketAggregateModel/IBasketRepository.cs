namespace EShop.Domain.AggregatesModel.BasketAggregateModel
{
    public interface IBasketRepository : IRepository<Basket>
    {
        Task<Basket> GetBasketByCustomerId(int customerId);
        Basket Add(Basket basket);
        Basket Update(Basket basket);
        BasketItem Update(BasketItem basketItem);
    }
}

