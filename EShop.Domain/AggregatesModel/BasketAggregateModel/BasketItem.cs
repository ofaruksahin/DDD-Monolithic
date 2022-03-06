namespace EShop.Domain.AggregatesModel.BasketAggregateModel
{
    public class BasketItem : Entity
    {
        public int BasketId { get; private set; }

        public int SellerId { get; private set; }
        public string SellerName { get; private set; }
        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Count { get; private set; }
        public decimal ExcludesTaxPrice { get; private set; }
        public decimal Tax { get; private set; }
        public decimal IncludingTaxPrice { get; private set; }

        protected BasketItem()
        {

        }

        private BasketItem(
            int sellerId,
            string sellerName,
            int productId,
            string productName,
            int count,
            decimal excludesTaxPrice,
            decimal tax,
            decimal includingTaxPrice
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
        }

        public static BasketItem Create(
            int sellerId,
            string sellerName,
            int productId,
            string productName,
            int count,
            decimal excludesTaxPrice,
            decimal tax,
            decimal includingTaxPrice
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

    }
}

