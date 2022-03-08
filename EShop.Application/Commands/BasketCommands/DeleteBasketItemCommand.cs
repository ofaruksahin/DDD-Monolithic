namespace EShop.Application.Commands.BasketCommands
{
    public class DeleteBasketItemCommand : IRequest<BaseResponse<bool>>
    {
        public int CustomerId { get; private set; }
        public int ProductId { get; private set; }

        public DeleteBasketItemCommand(int customerId, int productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }
    }

    public class DeleteBasketItemCommandHandler : BaseBasketCommands, IRequestHandler<DeleteBasketItemCommand, BaseResponse<bool>>
    {
        public DeleteBasketItemCommandHandler(IBasketRepository basketRepository) : base(basketRepository)
        {
        }

        public async Task<BaseResponse<bool>> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

