namespace EShop.API.Controllers
{
    //TODO: Sepete ürün ekleme ve sepetten ürün silme işlemleri kodlanacak
    public class BasketsController : BaseAPIController
    {
        public BasketsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("{customerId}")]
        public async Task<IActionResult> AddBasketItem(int customerId, CreateBasketItemCommand request)
        {
            request.CustomerId = customerId;
            var response = await _mediator.Send(request);
            return Response(response);
        }
    }
}

