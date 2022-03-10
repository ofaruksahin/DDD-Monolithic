namespace EShop.Application.Commands.BasketCommands
{
    public class GetBasketCommand : IRequest<BaseResponse<BasketDto>>
    {
        public int CustomerId { get; private set; }

        public GetBasketCommand(int customerId)
        {
            CustomerId = customerId;
        }
    }

    public class GetBasketCommandHandler : BaseBasketCommand, IRequestHandler<GetBasketCommand, BaseResponse<BasketDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetBasketCommandHandler(
            IBasketRepository basketRepository,
            ICustomerRepository customerRepository)
            : base(basketRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<BaseResponse<BasketDto>> Handle(GetBasketCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.CustomerId);
            if (customer == null)
                return BaseResponse<BasketDto>.Fail(null, "Böyle bir müşteri bulunamadı");

            var basket = await _basketRepository.GetBasketByCustomerId(request.CustomerId);
            if (basket == null)
                return BaseResponse<BasketDto>.Success(new BasketDto());

            BasketDto basketDto = new BasketDto();
            basketDto.Id = basket.Id;
            basketDto.CustomerId = basket.CustomerId;
            basketDto.ExcludesTaxPrice = basket.ExcludesTaxPrice;
            basketDto.Tax = basket.Tax;
            basketDto.IncludingTaxPrice = basket.IncludingTaxPrice;

            foreach (var basketItem in basket.BasketItems)
            {
                BasketItemDto basketItemDto = new BasketItemDto();
                basketItemDto.ProductId = basketItem.ProductId;
                basketItemDto.SellerName = basketItem.SellerName;
                basketItemDto.ProductName = basketItem.ProductName;
                basketItemDto.Count = basketItem.Count;
                basketItemDto.ExcludesTaxPrice = basketItem.ExcludesTaxPrice;
                basketItemDto.Tax = basketItem.Tax;
                basketItemDto.IncludingTaxPrice = basketItem.IncludingTaxPrice;
                basketItemDto.Status = basketItem.Status.Name;

                basketDto.BasketItems.Add(basketItemDto);
            }

            return BaseResponse<BasketDto>.Success(basketDto);
        }
    }
}

