using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Commands.OrderCommands
{
    public class CreateOrderCommand
    {
    }

    public class CreateOrderCommandHandler : BaseOrderCommand
    {
        public CreateOrderCommandHandler(IOrderRepository orderRepository) : base(orderRepository)
        {
        }
    }
}
