namespace EShop.Domain.Core.Abstractions
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseAPIController : ControllerBase
    {
        protected IMediator _mediator;

        public BaseAPIController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public IActionResult Response<T>(BaseResponse<T> response)
            => new OkObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
    }
}

