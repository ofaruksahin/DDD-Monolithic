namespace EShop.Application.Commands.ProductCommands
{
    public class CreateProductCommand : CreateProductDto, IRequest<BaseResponse<int>>
    {

    }

    public class CreateProductCommandHandler : BaseProductCommand, IRequestHandler<CreateProductCommand, BaseResponse<int>>
    {
        private ICategoryRepository _categoryRepository;
        public CreateProductCommandHandler(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
            : base(productRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponse<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            BaseResponse<int> response = new BaseResponse<int>();
            List<ProductAttribute> productAttributes = request.Attributes.Select(f => ProductAttribute.Create(f.Name, f.Value)).ToList();
            Product product = Product.Create(request.Name, request.Description, request.Quantity, request.Price, request.SellerId);
            request.Attributes.ForEach(item =>
            {
                ProductAttribute attribute = ProductAttribute.Create(item.Name, item.Value);
                product.AddAttribute(attribute);
            });

            var categories = await _categoryRepository.GetCategories();

            foreach (var id in request.CategoryIds)
            {
                var category = categories.FirstOrDefault(f => f.Id == id);
                if (category == null)
                {
                    response = BaseResponse<int>.Fail(0, $"Kategori bulunamadı");
                    break;
                }
                product.AddCategory(ProductCategory.Create(category.Id));
            }

            if (response.Messages.Any())
                return response;

            _productRepository.Add(product);
            var result = await _productRepository.UnitOfWork.SaveEntitiesAsync();
            if (!result)
                return BaseResponse<int>.Fail(0, "Ürün oluşturulamadı!");
            return BaseResponse<int>.Success(product.Id);
        }
    }
}

