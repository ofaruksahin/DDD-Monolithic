namespace EShop.Application.Commands.SellerCommands
{
    public class CreateSellerCommand : IRequest<BaseResponse<int>>
    {
        public string Name { get; set; }
    }

    public class CreateSellerCommandHandler : BaseSellerCommand, IRequestHandler<CreateSellerCommand, BaseResponse<int>>
    {
        public CreateSellerCommandHandler(ISellerRepository sellerRepository) : base(sellerRepository)
        {
        }

        public async Task<BaseResponse<int>> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            var existsSeller = await _sellerRepository.GetSellerByName(request.Name);

            if (existsSeller != null)
                return BaseResponse<int>.Fail(0, "Böyle bir satıcı zaten bulunuyor");

            Seller seller = Seller.Create(request.Name);
            seller.AddSeller();

            _sellerRepository.Add(seller);

            var isSuccess = await _sellerRepository.UnitOfWork.SaveEntitiesAsync();

            if (isSuccess)
                return BaseResponse<int>.Success(seller.Id);
            return BaseResponse<int>.Fail(0, "Satıcı oluşturulamadı");
        }
    }
}

