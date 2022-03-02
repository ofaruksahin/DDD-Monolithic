namespace EShop.Application.Commands.ProductCommands
{
    public class GetProductsCommand : IRequest<BaseResponse<List<ProductDto>>>
    {

    }

    public class GetProductsCommandHandler : BaseProductCommand,
        IRequestHandler<GetProductsCommand, BaseResponse<List<ProductDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;


        public GetProductsCommandHandler(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository
            )
            : base(productRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponse<List<ProductDto>>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProducts();
            var response = new List<ProductDto>();
            if (products.Any())
            {
                var categories = await _categoryRepository.GetCategories();

                foreach (var item in products)
                {
                    var product = new ProductDto();
                    product.Id = item.Id;
                    product.SellerId = item.SellerId;
                    product.Name = item.Name;
                    product.Description = item.Description;
                    product.Quantity = item.Quantity;
                    product.Price = item.Price;
                    product.Status = item.Status.Name;

                    foreach (var attr in item.Attributes)
                    {
                        ProductAttributeDto attrDto = new ProductAttributeDto();
                        attrDto.Id = attr.Id;
                        attrDto.Name = attr.Name;
                        attrDto.Value = attr.Value;
                        attrDto.Status = attr.Status.Name;

                        product.Attributes.Add(attrDto);
                    }

                    foreach (var cat in item.Categories)
                    {
                        var category = categories.FirstOrDefault(f => f.Id == cat.CategoryId);
                        if (category == null)
                            continue;
                        ProductCategoryDto catDto = new ProductCategoryDto();
                        catDto.Id = category.Id;
                        catDto.Name = category.Name;
                        catDto.Status = cat.Status.Name;
                        product.Categories.Add(catDto);
                    }

                    response.Add(product);
                }
            }
            return BaseResponse<List<ProductDto>>.Success(response);
        }
    }
}

