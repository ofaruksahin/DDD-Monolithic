using System;

namespace EShop.Application.Commands.CategoryCommands
{
    public class UpdateCategoryCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCategoryCommandHandler : BaseCategoryCommand, IRequestHandler<UpdateCategoryCommand, BaseResponse<bool>>
    {
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        public async Task<BaseResponse<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryById(request.Id);
            if (category == null)
                return BaseResponse<bool>.Fail(false, "Kategori bulunamadı");
            category.ChangeName(request.Name);
            _categoryRepository.Update(category);
            var result = await _categoryRepository.UnitOfWork.SaveEntitiesAsync();
            if (!result)
                return BaseResponse<bool>.Fail(false, "Kategori güncellenemedi");
            return BaseResponse<bool>.Success(true);
        }
    }
}

