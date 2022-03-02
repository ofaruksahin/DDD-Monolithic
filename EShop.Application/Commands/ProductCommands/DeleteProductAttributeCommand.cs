namespace EShop.Application.Commands.ProductCommands
{
    public class DeleteProductAttributeCommand : IRequest<BaseResponse<bool>>
    {
        public int ProductId { get; set; }
        public int AttributeId { get; set; }

        public DeleteProductAttributeCommand(int productId, int attributeId)
        {
            ProductId = productId;
            AttributeId = attributeId;
        }
    }

    public class DeleteProductAttributeCommandHandler : BaseProductCommand, IRequestHandler<DeleteProductAttributeCommand, BaseResponse<bool>>
    {
        public DeleteProductAttributeCommandHandler(IProductRepository productRepository) : base(productRepository)
        {
        }

        public async Task<BaseResponse<bool>> Handle(DeleteProductAttributeCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.ProductId);
            if (product == null)
                return BaseResponse<bool>.Fail(false, "Böyle bir ürün bulunamadı!");

            var attribute = product.Attributes.FirstOrDefault(f => f.Id == request.AttributeId);
            if (attribute == null)
                return BaseResponse<bool>.Fail(false, "Böyle bir ürün özelliği bulunamadı");

            attribute.SetStatusChangedToPassive();

            _productRepository.UpdateAttribute(attribute);

            var result = await _productRepository.UnitOfWork.SaveEntitiesAsync();
            if (!result)
                return BaseResponse<bool>.Fail(false, "Ürün özelliği pasife alınamadı");
            return BaseResponse<bool>.Success(true);
        }
    }
}

