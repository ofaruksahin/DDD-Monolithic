namespace EShop.Application.Commands.SellerCommands
{
    public class CreateSellerCommand : IRequest<BaseResponse<int>>
    {
        public string Name { get; set; }
    }
}

