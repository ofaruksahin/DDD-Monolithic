namespace EShop.Domain.AggregatesModel.SellerAggregateModel
{
    public interface ISellerRepository : IRepository<Seller>
    {
        Seller Add(Seller seller);

        Seller Update(Seller seller);

        Task<List<Seller>> GetSellers();

        Task<Seller> GetSeller(int sellerId);

        Task<Seller> GetSellerByName(string name);
    }
}