
namespace EShop.API.Controllers
{
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

        [HttpPost("{id}/attribute")]
        public async Task<IActionResult> InsertAttribute(int id, CreateProductAttributeCommand request)
        {
            request.ProductId = id;
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpDelete("{id}/attribute/{attributeId}")]
        public async Task<IActionResult> DeleteAttribute(int id, int attributeId)
        {
            var request = new DeleteProductAttributeCommand(id, attributeId);
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpPost("{id}/category/{categoryId}")]
        public async Task<IActionResult> InsertCategory(int id, int categoryId)
        {
            var request = new CreateProductCategoryCommand(id, categoryId);
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpDelete("{id}/category/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int id, int categoryId)
        {
            var request = new DeleteProductCategoryCommand(id, categoryId);
            var response = await _mediator.Send(request);
            return Response(response);
        }
    }
}

