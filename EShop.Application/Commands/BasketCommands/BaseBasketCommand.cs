namespace EShop.Application.Commands.BasketCommands
{
    public abstract class BaseBasketCommand
    {
        protected readonly IBasketRepository _basketRepository;

        protected BaseBasketCommand(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
    }
}

