namespace EShop.Application.Commands.BasketCommands
{
    public abstract class BaseBasketCommands
    {
        protected readonly IBasketRepository _basketRepository;

        protected BaseBasketCommands(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
    }
}

