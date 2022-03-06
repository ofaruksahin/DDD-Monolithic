namespace EShop.Domain.AggregatesModel.BasketAggregateModel
{
    public class Basket : Entity, IAggregateRoot
    {
        public int CustomerId { get; private set; }

        public decimal ExcludesTaxPrice
        {
            get => BasketItems
                .Where(f => f.Status != null && f.Status.Id == EnumStatus.Active.Id)
                .Sum(f => f.ExcludesTaxPrice);
            private set { }
        }

        public decimal Tax
        {
            get => BasketItems
                .Where(f => f.Status != null && f.Status.Id == EnumStatus.Active.Id)
                .Sum(f => f.Tax);
            private set { }
        }

        public decimal IncludingTaxPrice
        {
            get => BasketItems
                .Where(f => f.Status != null && f.Status.Id == EnumStatus.Active.Id)
                .Sum(f => f.IncludingTaxPrice);
            private set { }
        }

        private readonly List<BasketItem> _basketItems;
        public IReadOnlyList<BasketItem> BasketItems => _basketItems;

        protected Basket()
        {
            _basketItems = new List<BasketItem>();
        }

        private Basket(
            int customerId,
            List<BasketItem> basketItems = default
            )
        {
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

    }
}

