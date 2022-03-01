namespace EShop.Application.Commands.CategoryCommands
{
    public class GetCategoriesCommand : IRequest<BaseResponse<List<CategoryDto>>>
    {

    }

    public class GetCategoriesCommandHandler : BaseCategoryCommand, IRequestHandler<GetCategoriesCommand, BaseResponse<List<CategoryDto>>>
    {
        public GetCategoriesCommandHandler(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        public async Task<BaseResponse<List<CategoryDto>>> Handle(GetCategoriesCommand request, CancellationToken cancellationToken)
        {
            List<CategoryDto> response = new List<CategoryDto>();

            var categories = await _categoryRepository.GetCategories();

            response = categories.Select(f => new CategoryDto(f.Id, f.Name, f.Status.Name)).ToList();

            return BaseResponse<List<CategoryDto>>.Success(response);
        }
    }
}

