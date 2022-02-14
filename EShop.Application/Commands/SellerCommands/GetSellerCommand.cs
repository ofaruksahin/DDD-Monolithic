namespace EShop.Application.Commands.SellerCommands
{
    public class GetSellerCommand : IRequest<BaseResponse<GetSellerCommandResponse>>
    {
        public int Id { get; set; }

        public GetSellerCommand(int id)
        {
            Id = id;
        }
    }

    public class GetSellerCommandResponse
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

        public GetSellerCommandResponse(int id, string name, string sellerStatus)
        {
            Id = id;
            Name = name;
            SellerStatus = sellerStatus;
        }
    }

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

