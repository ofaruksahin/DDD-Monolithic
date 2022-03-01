namespace EShop.API.Controllers
{
    //TODO: Temel müşteri işlemleri
    //TODO: Temel müşteri adres işlemleri
    public class CustomersController : BaseAPIController
    {
        public CustomersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateCustomerCommand request)
        {
            var response = await _mediator.Send(request);
            return Response(response);
        }
    }
}

