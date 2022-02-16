namespace EShop.Application.Commands.ProductCommands
{
    public abstract class BaseProductCommand
    {
        protected IProductRepository _productRepository;

        protected BaseProductCommand(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
    }
}

