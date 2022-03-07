namespace EShop.Application.Commands.ProductCommands
{
    public class CreateProductAttributeCommand : CreateProductAttributeDto, IRequest<BaseResponse<int>>
    {
        public int ProductId { get; set; }
    }

    public class CreateProductAttributeCommandHandler : BaseProductCommand, IRequestHandler<CreateProductAttributeCommand, BaseResponse<int>>
    {
        public CreateProductAttributeCommandHandler(IProductRepository productRepository) : base(productRepository)
        {
        }

        public async Task<BaseResponse<int>> Handle(CreateProductAttributeCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.ProductId);
            if (product == null)
                return BaseResponse<int>.Fail(0, "Böyle bir ürün bulunamadı");
            var attribute = ProductAttribute.Create(request.Name, request.Value);
            product.AddAttribute(attribute);

            //_productRepository.UpdateAttribute(attribute);
            _productRepository.Update(product);
            var result = await _productRepository.UnitOfWork.SaveEntitiesAsync();
            if (!result)
                return BaseResponse<int>.Fail(0, "Ürüne özellik eklenemedi");
            return BaseResponse<int>.Success(attribute.Id);
        }
    }
}

