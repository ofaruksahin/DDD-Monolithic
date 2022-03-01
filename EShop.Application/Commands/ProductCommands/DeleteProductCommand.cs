namespace EShop.Application.Commands.ProductCommands
{
    public class DeleteProductCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; private set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteProductCommandHandler : BaseProductCommand, IRequestHandler<DeleteProductCommand, BaseResponse<bool>>
    {
        public DeleteProductCommandHandler(IProductRepository productRepository) : base(productRepository)
        {
        }

        public async Task<BaseResponse<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var exists = await _productRepository.GetProductById(request.Id);
            if (exists == null)
                return BaseResponse<bool>.Fail(false, "Böyle bir ürün bulunamadı");

            exists.ChangeStatusToPassive();
            _productRepository.Update(exists);

            var result = await _productRepository.UnitOfWork.SaveEntitiesAsync();

            if (!result)
                return BaseResponse<bool>.Fail(false, "Ürün pasif duruma alınamadı");
            return BaseResponse<bool>.Success(true, "Ürün başarıyla pasif edildi");
        }
    }
}

