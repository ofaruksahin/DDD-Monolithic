using System;
namespace EShop.Application.Commands.SellerCommands
{
    public class GetSellersCommand : IRequest<BaseResponse<List<GetSellersCommandResponse>>>
    {

    }

    public class GetSellersCommandResponse
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string SellerStatus
        {
            get;
            set;
        }

        public GetSellersCommandResponse(int id, string name, string sellerStatus)
        {
            Id = id;
            Name = name;
            SellerStatus = sellerStatus;
        }
    }

    public class GetSellersCommandHandler : BaseSellerCommand,
    IRequestHandler<GetSellersCommand, BaseResponse<List<GetSellersCommandResponse>>>
    {
        public GetSellersCommandHandler(ISellerRepository sellerRepository) : base(sellerRepository)
        {
        }

        public async Task<BaseResponse<List<GetSellersCommandResponse>>> Handle(GetSellersCommand request, CancellationToken cancellationToken)
        {
            var sellers = await _sellerRepository.GetSellers();
            List<GetSellersCommandResponse> sellersResponse = sellers.Select(f => new GetSellersCommandResponse(f.Id, f.Name, f.Status.Name)).ToList();
            return BaseResponse<List<GetSellersCommandResponse>>.Success(sellersResponse);
        }
    }
}

