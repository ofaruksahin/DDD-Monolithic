namespace EShop.Application.Commands.OrderCommands
{
    public class GetOrdersCommand : IRequest<BaseResponse<List<OrderDto>>>
    {
        public int CustomerId { get; private set; }

        public GetOrdersCommand(int customerId)
        {
            CustomerId = customerId;
        }
    }

    public class GetOrdersCommandHandler : BaseOrderCommand,IRequestHandler<GetOrdersCommand,BaseResponse<List<OrderDto>>>
    {
        public GetOrdersCommandHandler(IOrderRepository orderRepository) : base(orderRepository)
        {
        }

        public async Task<BaseResponse<List<OrderDto>>> Handle(GetOrdersCommand request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrders(request.CustomerId);
            if(orders == null)
                return BaseResponse<List<OrderDto>>.Fail(new List<OrderDto>(),"Daha önce bir siparişiniz bulunamadı");

            List<OrderDto> orderDtos = new List<OrderDto>();
            foreach (var order in orders)
            {
                OrderDto orderDto = new OrderDto();
                orderDto.CustomerId = request.CustomerId;
                orderDto.ExcludesTaxPrice = order.ExcludesTaxPrice;
                orderDto.Tax = order.Tax;
                orderDto.IncludingTaxPrice = order.IncludingTaxPrice;
                orderDto.OrderItems = new List<OrderItemDto>();
                orderDto.Status = order.Status.Name;

                foreach (var orderOrderItem in order.OrderItems)
                {
                    OrderItemDto orderItemDto = new OrderItemDto();
                    orderItemDto.SellerId = orderOrderItem.SellerId;
                    orderItemDto.SellerName = orderOrderItem.SellerName;
                    orderItemDto.ProductId = orderOrderItem.ProductId;
                    orderItemDto.ProductName = orderOrderItem.ProductName;
                    orderItemDto.Count = orderOrderItem.Count;
                    orderItemDto.ExcludesTaxPrice = orderOrderItem.ExcludesTaxPrice;
                    orderItemDto.Tax = orderOrderItem.Tax;
                    orderItemDto.IncludingTaxPrice = orderOrderItem.IncludingTaxPrice;
                    orderItemDto.Status = orderOrderItem.Status.Name;


                    orderDto.OrderItems.Add(orderItemDto);
                }
                orderDtos.Add(orderDto);
            }
            
            return BaseResponse<List<OrderDto>>.Success(orderDtos);
        }
    }
}
