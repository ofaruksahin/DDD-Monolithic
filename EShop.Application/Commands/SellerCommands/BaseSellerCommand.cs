namespace EShop.Application.Commands.SellerCommands
{
    public abstract class BaseSellerCommand
    {
        protected readonly ISellerRepository _sellerRepository;

        protected BaseSellerCommand(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository ?? throw new ArgumentNullException(nameof(sellerRepository));
        }
    }
}

