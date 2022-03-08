namespace EShop.Domain.AggregatesModel.BasketAggregateModel
{
    public class BasketItem : Entity
    {
        public int SellerId { get; private set; }
        public string SellerName { get; private set; }
        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Count { get; private set; }
        public double ExcludesTaxPrice { get; private set; }
        public double Tax { get; private set; }
        public double IncludingTaxPrice { get; private set; }

        protected BasketItem()
        {
        }

        private BasketItem(
            int sellerId,
            string sellerName,
            int productId,
            string productName,
            int count,
            double excludesTaxPrice,
            double tax,
            double includingTaxPrice
            )
        {
            SellerId = sellerId;
            SellerName = sellerName;
            ProductId = productId;
            ProductName = productName;
            Count = count;
            ExcludesTaxPrice = excludesTaxPrice;
            Tax = tax;
            IncludingTaxPrice = includingTaxPrice;
            StatusId = EnumStatus.Active.Id;
        }

        public static BasketItem Create(
            int sellerId,
            string sellerName,
            int productId,
            string productName,
            int count,
            double excludesTaxPrice,
            double tax,
            double includingTaxPrice
            )
        {
            return new BasketItem(
                sellerId,
                sellerName,
                productId,
                productName,
                count,
                excludesTaxPrice,
                tax,
                includingTaxPrice
                );
        }

        public void IncreaseCount(int count)
        {
            Count += count;
        }
    }
}

