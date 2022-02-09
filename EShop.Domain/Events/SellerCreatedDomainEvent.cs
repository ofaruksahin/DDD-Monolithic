using System;
using EShop.Domain.AggregatesModel.SellerAggregateModel;
using MediatR;

namespace EShop.Domain.Events
{
	public class SellerCreatedDomainEvent : INotification
	{
		public Seller Seller
        {
			get;
			private set;
        }

        public SellerCreatedDomainEvent(Seller seller)
        {
			Seller = seller;
        }
	}
}

