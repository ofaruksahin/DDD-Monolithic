using System;

namespace EShop.Application.Commands.CategoryCommands
{
    public class GetCategoriesCommandHandler : BaseCategoryCommand, IRequestHandler<GetCategoriesCommand, BaseResponse<List<GetCategoriesCommandResponse>>>
    {
        public GetCategoriesCommandHandler(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        public async Task<BaseResponse<List<GetCategoriesCommandResponse>>> Handle(GetCategoriesCommand request, CancellationToken cancellationToken)
        {
            List<GetCategoriesCommandResponse> response = new List<GetCategoriesCommandResponse>();

            var categories = await _categoryRepository.GetCategories();

            response = categories.Select(f => new GetCategoriesCommandResponse(f.Id, f.Name, f.Status.Name)).ToList();

            return BaseResponse<List<GetCategoriesCommandResponse>>.Success(response);
        }
    }
}

