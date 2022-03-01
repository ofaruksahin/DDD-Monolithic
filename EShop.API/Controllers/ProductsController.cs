
namespace EShop.API.Controllers
{
    //TODO: Ürünlere kategori ekleme ve silme yapılmalı
    //TODO: Ürünlere attribute ekleme ve silme yapılmalı
    public class ProductsController : BaseAPIController
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var request = new GetProductsCommand();
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var request = new GetProductCommand(id);
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateProductCommand request)
        {
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteProductCommand(id);
            var response = await _mediator.Send(request);
            return Response(response);
        }
    }
}

