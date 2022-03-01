namespace EShop.Domain.AggregatesModel.ProductAggregateModel
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Add(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();
        Product Update(Product product);
    }
}

