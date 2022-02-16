
namespace EShop.API.Controllers
{
    public class ProductsController : BaseAPIController
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateProductCommand request)
        {
            var response = await _mediator.Send(request);
            return Response(response);
        }
    }
}

