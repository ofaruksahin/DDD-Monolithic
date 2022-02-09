using System;
using EShop.Domain.Core;

namespace EShop.Domain.AggregatesModel.SellerAggregateModel
{
	public interface ISellerRepository : IRepository<Seller>
	{
		Seller Add(Seller seller);
		void Update(Seller seller);
		Task<Seller> GetSeller(int sellerId);
	}
}

