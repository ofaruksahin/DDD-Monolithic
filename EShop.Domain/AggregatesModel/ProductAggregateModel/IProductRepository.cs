namespace EShop.Domain.AggregatesModel.ProductAggregateModel
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Add(Product product);
    }
}

