namespace EShop.Domain.AggregatesModel.ProductAggregateModel
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Add(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();
        Product Update(Product product);
        ProductAttribute UpdateAttribute(ProductAttribute productAttribute);
        ProductCategory UpdateCategory(ProductCategory productCategory);
        Task<List<Product>> GetProductsBySeller(int sellerId);
    }
}

