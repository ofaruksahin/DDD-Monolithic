namespace EShop.Application.Commands.SellerCommands
{
    public class GetSellerCommand : IRequest<BaseResponse<SellerDto>>
    {
        public int Id { get; set; }

        public GetSellerCommand(int id)
        {
            Id = id;
        }
    }

    public class GetSellerCommandHandler : BaseSellerCommand, IRequestHandler<GetSellerCommand, BaseResponse<SellerDto>>
    {
        public GetSellerCommandHandler(ISellerRepository sellerRepository) : base(sellerRepository)
        {
        }

        public async Task<BaseResponse<SellerDto>> Handle(GetSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = await _sellerRepository.GetSeller(request.Id);
            if (seller == null)
                return BaseResponse<SellerDto>.Fail(null, "Böyle bir satıcı bulunamadı");
            return BaseResponse<SellerDto>.Success(new SellerDto(seller.Id, seller.Name, seller.Status.Name));
        }
    }
}

