namespace EShop.Application.Commands.SellerCommands
{
    public class GetSellersCommand : IRequest<BaseResponse<List<SellerDto>>>
    {

    }

    public class GetSellersCommandHandler : BaseSellerCommand,
    IRequestHandler<GetSellersCommand, BaseResponse<List<SellerDto>>>
    {
        public GetSellersCommandHandler(ISellerRepository sellerRepository) : base(sellerRepository)
        {
        }

        public async Task<BaseResponse<List<SellerDto>>> Handle(GetSellersCommand request, CancellationToken cancellationToken)
        {
            var sellers = await _sellerRepository.GetSellers();
            List<SellerDto> sellersResponse = sellers.Select(f => new SellerDto(f.Id, f.Name, f.Status.Name)).ToList();
            return BaseResponse<List<SellerDto>>.Success(sellersResponse);
        }
    }
}

