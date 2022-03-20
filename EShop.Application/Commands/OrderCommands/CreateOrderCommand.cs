using EShop.Application.Dtos.OrderDtos;

namespace EShop.Application.Commands.OrderCommands
{
    public class CreateOrderCommand : CreateOrderDto, IRequest<BaseResponse<int>>
    {
        public CreateOrderCommand(int customerId) : base(customerId)
        {
        }
    }

    public class CreateOrderCommandHandler : BaseOrderCommand, IRequestHandler<CreateOrderCommand, BaseResponse<int>>
    {
        private readonly IBasketRepository _basketRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IBasketRepository basketRepository) : base(orderRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<BaseResponse<int>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasketByCustomerId(request.CustomerId);
            if(basket == null)
                return BaseResponse<int>.Fail(0,"Sepetiniz boş");

            Order order = Order.Create(request.CustomerId);

            foreach (var basketItem in basket.BasketItems)
            {
                OrderItem orderItem = OrderItem.Create(basketItem.SellerId, basketItem.SellerName, basketItem.ProductId,
                    basketItem.ProductName, basketItem.Count, basketItem.ExcludesTaxPrice, basketItem.Tax,
                    basketItem.IncludingTaxPrice);
                order.AddOrderItem(orderItem);
            }

            basket.SetStatusChangedToPassive();

            _basketRepository.Update(basket);
            _orderRepository.Add(order);

            var result = await _orderRepository.UnitOfWork.SaveEntitiesAsync();
            if(!result)
                return BaseResponse<int>.Fail(0,"Sipariş oluşturulamadı");
            return BaseResponse<int>.Success(order.Id);
        }
    }
}
