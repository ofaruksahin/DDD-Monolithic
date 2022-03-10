namespace EShop.Application.Commands.OrderCommands
{
    public class BaseOrderCommand
    {
        protected readonly IOrderRepository _orderRepository;

        public BaseOrderCommand(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
    }
}
