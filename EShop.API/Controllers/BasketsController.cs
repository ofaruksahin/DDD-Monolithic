namespace EShop.API.Controllers
{
    public class BasketsController : BaseAPIController
    {
        public BasketsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetBasket(int customerId)
        {
            var request = new GetBasketCommand(customerId);
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpPost("{customerId}")]
        public async Task<IActionResult> AddBasketItem(int customerId, CreateBasketItemCommand request)
        {
            request.CustomerId = customerId;
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpDelete("{customerId}/{productId}")]
        public async Task<IActionResult> DeleteBasketItem(int customerId, int productId)
        {
            var request = new DeleteBasketItemCommand(customerId, productId);
            var response = await _mediator.Send(request);
            return Response(response);
        }
    }
}

