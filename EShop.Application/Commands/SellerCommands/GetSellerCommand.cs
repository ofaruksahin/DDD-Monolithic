using System;
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
    }
}

