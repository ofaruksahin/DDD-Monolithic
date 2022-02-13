using System;

namespace EShop.Application.Commands.SellerCommands
{
    public class GetSellerCommandHandler : BaseSellerCommand, IRequestHandler<GetSellerCommand, BaseResponse<GetSellerCommandResponse>>
    {
        public GetSellerCommandHandler(ISellerRepository sellerRepository) : base(sellerRepository)
        {
        }

        public async Task<BaseResponse<GetSellerCommandResponse>> Handle(GetSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = await _sellerRepository.GetSeller(request.Id);
            if (seller == null)
                return BaseResponse<GetSellerCommandResponse>.Fail(null, "Böyle bir satıcı bulunamadı");
            return BaseResponse<GetSellerCommandResponse>.Success(new GetSellerCommandResponse(seller.Id, seller.Name, seller.Status.Name));
        }
    }
}

