using System;
namespace EShop.Application.Commands.SellerCommands
{
    public class DeleteSellerCommand : IRequest<BaseResponse<NoContent>>
    {
        public int Id { get; set; }

        public DeleteSellerCommand(int id)
        {
            Id = id;
        }
    }
}

