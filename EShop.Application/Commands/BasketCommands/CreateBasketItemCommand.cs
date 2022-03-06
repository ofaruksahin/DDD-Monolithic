namespace EShop.Application.Commands.BasketCommands
{
    public class CreateBasketItemCommand : CreateBasketDto, IRequest<BaseResponse<int>>
    {

    }

    public class CreateBasketItemCommandHandler : BaseBasketCommands, IRequestHandler<CreateBasketItemCommand, BaseResponse<int>>
    {
        public CreateBasketItemCommandHandler(IBasketRepository basketRepository) : base(basketRepository)
        {
        }

        public async Task<BaseResponse<int>> Handle(CreateBasketItemCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}

