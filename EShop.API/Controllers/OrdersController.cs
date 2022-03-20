namespace EShop.API.Controllers
{
    public class OrdersController : BaseAPIController
    {
        public OrdersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> List(int customerId)
        {
            GetOrdersCommand request = new GetOrdersCommand(customerId);
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpPost("{customerId}")]
        public async Task<IActionResult> Insert(int customerId)
        {
            CreateOrderCommand request = new CreateOrderCommand(customerId);
            var response = await _mediator.Send(request);
            return Response(response);
        }
    }
}

