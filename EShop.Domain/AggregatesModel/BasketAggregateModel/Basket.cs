namespace EShop.Domain.AggregatesModel.BasketAggregateModel
{
    public class Basket : Entity, IAggregateRoot
    {
        public int CustomerId { get; private set; }

        public double ExcludesTaxPrice
        {
            get => BasketItems
                .Where(f => f.Status.Id == EnumStatus.Active.Id)
                .Sum(f => f.ExcludesTaxPrice * f.Count);
            private set { }
        }

        public double Tax
        {
            get => BasketItems
                .Where(f => f.Status.Id == EnumStatus.Active.Id)
                .Sum(f => f.Tax * f.Count);
            private set { }
        }

        public double IncludingTaxPrice
        {
            get => BasketItems
                .Where(f => f.Status.Id == EnumStatus.Active.Id)
                .Sum(f => f.IncludingTaxPrice * f.Count);
            private set { }
        }

        private readonly List<BasketItem> _basketItems;
        public IReadOnlyList<BasketItem> BasketItems => _basketItems;

        protected Basket()
        {
            _basketItems = new List<BasketItem>();
            StatusId = EnumStatus.Active.Id;
        }

        private Basket(
            int customerId,
            List<BasketItem> basketItems = default
            )
        {
            StatusId = EnumStatus.Active.Id;
            CustomerId = customerId;

            if (basketItems == default)
            {
                _basketItems = new List<BasketItem>();
            }
            else
            {
                _basketItems = basketItems;
            }
        }

        public static Basket CreateBasket(
            int customerId,
            List<BasketItem> basketItems = default
            )
        {
            return new Basket(
                customerId,
                basketItems
                );
        }

        public void AddBasketItem(BasketItem basketItem)
        {
            var basketIt = BasketItems.FirstOrDefault(f => f.SellerId == basketItem.SellerId && f.ProductId == basketItem.ProductId);
            if (basketIt != null)
            {
                basketIt.IncreaseCount(basketItem.Count);
            }
            else
            {
                _basketItems.Add(basketItem);
            }
        }
    }
}

