namespace EShop.Application.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest<BaseResponse<int>>
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public List<CreateProductAttributeDto> Attributes { get; set; } = new List<CreateProductAttributeDto>();
    }

    public class CreateProductCommandHandler : BaseProductCommand, IRequestHandler<CreateProductCommand, BaseResponse<int>>
    {
        public CreateProductCommandHandler(IProductRepository productRepository) : base(productRepository)
        {
        }

        public async Task<BaseResponse<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            List<ProductAttribute> productAttributes = request.Attributes.Select(f => new ProductAttribute(f.Name, f.Value)).ToList();
            Product product = new Product(request.Name, request.Description, request.Quantity, request.Price, request.SellerId, request.CategoryId, productAttributes);
            _productRepository.Add(product);
            var result = await _productRepository.UnitOfWork.SaveEntitiesAsync();
            if (!result)
                return BaseResponse<int>.Fail(0, "Ürün oluşturulamadı!");
            return BaseResponse<int>.Success(product.Id);
        }
    }
}

