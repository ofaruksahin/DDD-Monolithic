namespace EShop.Application.Commands.ProductCommands
{
    public class GetProductCommand : IRequest<BaseResponse<ProductDto>>
    {
        public int Id { get; private set; }

        public GetProductCommand(int id)
        {
            Id = id;
        }
    }

    public class GetProductCommandHandler : BaseProductCommand, IRequestHandler<GetProductCommand, BaseResponse<ProductDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetProductCommandHandler(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository
            )
            : base(productRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponse<ProductDto>> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            var exists = await _productRepository.GetProductById(request.Id);
            if (exists == null)
                return BaseResponse<ProductDto>.Fail(null, "Böyle bir ürün bulunamadı");
            ProductDto response = new ProductDto();
            response.Id = exists.Id;
            response.SellerId = exists.SellerId;
            response.Name = exists.Name;
            response.Description = exists.Description;
            response.Quantity = exists.Quantity;
            response.Price = exists.Price;
            response.Status = exists.Status.Name;

            foreach (var attribute in exists.Attributes)
            {
                ProductAttributeDto attrDto = new ProductAttributeDto();
                attrDto.Id = attribute.Id;
                attrDto.Name = attribute.Name;
                attrDto.Value = attribute.Value;
                response.Attributes.Add(attrDto);
            }

            var categories = await _categoryRepository.GetCategories();

            foreach (var category in exists.Categories)
            {
                var _category = categories.FirstOrDefault(f => f.Id == category.CategoryId);
                if (_category == null)
                    continue;
                ProductCategoryDto productCatDto = new ProductCategoryDto();
                productCatDto.Id = _category.Id;
                productCatDto.Name = _category.Name;
                response.Categories.Add(productCatDto);
            }

            return BaseResponse<ProductDto>.Success(response);
        }
    }
}

