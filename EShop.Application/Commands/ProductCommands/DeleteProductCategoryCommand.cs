namespace EShop.Application.Commands.ProductCommands
{
    public class DeleteProductCategoryCommand : IRequest<BaseResponse<bool>>
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public DeleteProductCategoryCommand(int productId, int categoryId)
        {
            ProductId = productId;
            CategoryId = categoryId;
        }
    }

    public class DeleteProductCategoryCommandHandle : BaseProductCommand, IRequestHandler<DeleteProductCategoryCommand, BaseResponse<bool>>
    {
        public DeleteProductCategoryCommandHandle(IProductRepository productRepository) : base(productRepository)
        {
        }

        public async Task<BaseResponse<bool>> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var exists = await _productRepository.GetProductById(request.ProductId);

            if (exists == null)
                return BaseResponse<bool>.Fail(false, "Böyle bir ürün bulunamadı");

            var category = exists.Categories.FirstOrDefault(f => f.CategoryId == request.CategoryId && f.Status.Id == EnumStatus.Active.Id);

            if (category == null)
                return BaseResponse<bool>.Fail(false, "Bu ürün zaten bu kategoriye atanmamış");

            category.SetStatusChangedToPassive();

            _productRepository.UpdateCategory(category);

            var result = await _productRepository.UnitOfWork.SaveEntitiesAsync();
            if (!result)
                return BaseResponse<bool>.Fail(false, "Ürün ilgili kategoriden kaldırılamadı");
            return BaseResponse<bool>.Success(true);
        }
    }
}

