using System;
namespace EShop.Application.Commands.CategoryCommands
{
    public class DeleteCategoryCommand : IRequest<BaseResponse<NoContent>>
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteCategoryCommandHandler : BaseCategoryCommand, IRequestHandler<DeleteCategoryCommand, BaseResponse<NoContent>>
    {
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        public async Task<BaseResponse<NoContent>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var exists = await _categoryRepository.GetCategoryById(request.Id);
            if (exists == null)
                return BaseResponse<NoContent>.Fail(new NoContent(), "Böyle bir kategori bulunamadı");
            exists.SetStatusChangedToPassive();
            _categoryRepository.Update(exists);
            var result = await _categoryRepository.UnitOfWork.SaveEntitiesAsync();
            if (!result)
                return BaseResponse<NoContent>.Fail(new NoContent(), "Kategori pasife alınamadı");
            return BaseResponse<NoContent>.Success(new NoContent());
        }
    }
}

