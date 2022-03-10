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

    public class DeleteBasketItemCommandHandler : BaseBasketCommand, IRequestHandler<DeleteBasketItemCommand, BaseResponse<bool>>
    {
        private readonly ICustomerRepository _customerRepository;
        public DeleteBasketItemCommandHandler(
            IBasketRepository basketRepository,
            ICustomerRepository customerRepository
            ) 
            : base(basketRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var customer =await _customerRepository.GetCustomerById(request.CustomerId);
            if(customer == null)
                return BaseResponse<bool>.Fail(false,"Müşteri bulunamadı");
            var basket = await _basketRepository.GetBasketByCustomerId(request.CustomerId);
            if(basket == null)
                return BaseResponse<bool>.Success(true);
            var basketItem = basket.BasketItems.FirstOrDefault(f => f.ProductId == request.ProductId);
            if(basketItem == null)
                return BaseResponse<bool>.Fail(false,"Böyle bir ürün bulunamadı");
            basketItem.StatusChangedToPassive();
            _basketRepository.Update(basket);
            var result = await _basketRepository.UnitOfWork.SaveEntitiesAsync();
            if(!result)
                return BaseResponse<bool>.Fail(false,"Sepetten ürün silinemedi");
            return BaseResponse<bool>.Success(result);
        }
    }
}

