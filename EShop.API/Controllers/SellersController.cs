namespace EShop.API.Controllers
{
    public class SellersController : BaseAPIController
    {
        public SellersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var request = new GetSellersCommand();
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = new GetSellerCommand(id);
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateSellerCommand command)
        {
            var response = await _mediator.Send(command);
            return Response(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteSellerCommand(id);
            var response = await _mediator.Send(request);
            return Response(response);
        }
    }
}

