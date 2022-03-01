namespace EShop.Application.Commands.CategoryCommands
{
    public class GetCategoryCommand : IRequest<BaseResponse<CategoryDto>>
    {
        public int Id { get; set; }

        public GetCategoryCommand(int id)
        {
            Id = id;
        }
    }

    public class GetCategoryCommandHandler : BaseCategoryCommand, IRequestHandler<GetCategoryCommand, BaseResponse<CategoryDto>>
    {
        public GetCategoryCommandHandler(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        public async Task<BaseResponse<CategoryDto>> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
        {
            var exists = await _categoryRepository.GetCategoryById(request.Id);
            if (exists == null)
                return BaseResponse<CategoryDto>.Fail(null, "Böyle bir kategori bulunamadı");
            return BaseResponse<CategoryDto>.Success(new CategoryDto(exists.Id, exists.Name, exists.Status.Name));
        }
    }
}

