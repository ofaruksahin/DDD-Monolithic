namespace EShop.API.Controllers
{
    //TODO: Temel müşteri işlemleri
    //TODO: Temel müşteri adres işlemleri
    public class CustomersController : BaseAPIController
    {
        public CustomersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var request = new GetCustomersCommand();
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = new GetCustomerCommand(id);
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateCustomerCommand request)
        {
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteCustomerCommand(id);
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpPost("{id}/addresses")]
        public async Task<IActionResult> InsertAddress(int id, CreateCustomerAddressCommand request)
        {
            request.CustomerId = id;
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpDelete("{id}/addresses/{addressId}")]
        public async Task<IActionResult> DeleteAddress(int id, int addressId)
        {
            var request = new DeleteCustomerAddressCommand(id, addressId);
            var response = await _mediator.Send(request);
            return Response(response);
        }
    }
}

