using System;

namespace EShop.Application.Commands.SellerCommands
{
    public class GetSellersCommandHandler : BaseSellerCommand,
        IRequestHandler<GetSellersCommand, BaseResponse<List<GetSellersCommandResponse>>>
    {
        public GetSellersCommandHandler(ISellerRepository sellerRepository) : base(sellerRepository)
        {
        }

        public async Task<BaseResponse<List<GetSellersCommandResponse>>> Handle(GetSellersCommand request, CancellationToken cancellationToken)
        {
            var sellers = await _sellerRepository.GetSellers();
            List<GetSellersCommandResponse> sellersResponse = sellers.Select(f => new GetSellersCommandResponse
            {
                Id = f.Id,
                Name = f.Name,
                SellerStatus = f.Status.Name
            }).ToList();
            return BaseResponse<List<GetSellersCommandResponse>>.Success(sellersResponse);
        }
    }
}

