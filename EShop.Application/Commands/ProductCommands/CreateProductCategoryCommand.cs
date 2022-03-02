namespace EShop.Application.Commands.ProductCommands
{
    public class CreateProductCategoryCommand : IRequest<BaseResponse<int>>
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public CreateProductCategoryCommand(int productId, int category)
        {
            ProductId = productId;
            CategoryId = category;
        }
    }

    public class CreateProductCategoryCommandHandler : BaseProductCommand, IRequestHandler<CreateProductCategoryCommand, BaseResponse<int>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateProductCategoryCommandHandler(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository
            )
            : base(productRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponse<int>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var exists = await _productRepository.GetProductById(request.ProductId);
            if (exists == null)
                return BaseResponse<int>.Fail(0, "Böyle bir ürün bulunamadı");

            var existsCategory = exists.Categories.FirstOrDefault(f => f.CategoryId == request.CategoryId && f.Status.Id == EnumStatus.Active.Id);

            if (existsCategory != null)
                return BaseResponse<int>.Fail(0, "Ürün bu kategoriye zaten tanımlanmış");

            var category = await _categoryRepository.GetCategoryById(request.CategoryId);
            if (category == null)
                return BaseResponse<int>.Fail(0, "Böyle bir kategori bulunamadı");

            var pCat = ProductCategory.Create(request.CategoryId);

            exists.AddCategory(pCat);

            _productRepository.Update(exists);
            var result = await _productRepository.UnitOfWork.SaveEntitiesAsync();
            if (!result)
                return BaseResponse<int>.Fail(0, "Ürün ilgili kategoriye tanımlanamadı");
            return BaseResponse<int>.Success(pCat.Id);
        }
    }
}

