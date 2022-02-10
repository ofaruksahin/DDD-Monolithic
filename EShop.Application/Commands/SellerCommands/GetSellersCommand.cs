﻿using System;
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
    }
}
