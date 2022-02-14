using EShop.Application.Commands.CategoryCommands;

namespace EShop.API.Controllers
{
    public class CategoriesController : BaseAPIController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var request = new GetCategoriesCommand();
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = new GetCategoryCommand(id);
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateCategoryCommand request)
        {
            var response = await _mediator.Send(request);
            return Response(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteCategoryCommand(id);
            var response = await _mediator.Send(request);
            return Response(response);
        }
    }
}

