using System;
using EShop.Domain.Core;

namespace EShop.Domain.AggregatesModel.SellerAggregateModel
{
	public class Seller : Entity, IAggregateRoot
	{
        public string Name
        {
            get;
            private set;
        }

        protected Seller()
        {

        }

        public Seller(string name)
        {
            Name = name;
        }
    }
}

