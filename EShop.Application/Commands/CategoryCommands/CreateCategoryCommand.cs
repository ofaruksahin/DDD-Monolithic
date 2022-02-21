namespace EShop.Application.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest<BaseResponse<int>>
    {
        public string Name { get; set; }
    }

    public class CreateCategoryCommandHandler : BaseCategoryCommand, IRequestHandler<CreateCategoryCommand, BaseResponse<int>>
    {
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
            : base(categoryRepository)
        {
        }

        public async Task<BaseResponse<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var exists = await _categoryRepository.GetCategoryByName(request.Name);

            if (exists != null)
                return BaseResponse<int>.Fail(0, "Böyle bir kategori zaten mevcut");

            Category category = Category.Create(request.Name);

            _categoryRepository.Add(category);

            var result = await _categoryRepository.UnitOfWork.SaveEntitiesAsync();

            if (!result)
                return BaseResponse<int>.Fail(0, "Kategori oluşturulamadı");

            return BaseResponse<int>.Success(category.Id);
        }
    }
}

