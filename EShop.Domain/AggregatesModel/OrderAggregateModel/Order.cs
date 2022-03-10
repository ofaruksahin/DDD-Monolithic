namespace EShop.Domain.AggregatesModel.OrderAggregateModel
{
    public class Order : Entity, IAggregateRoot
    {
        public int CustomerId
        {
            get; 
            private set;
        }

        public double ExcludesTaxPrice
        {
            get; 
            private set;
        }
        public double Tax { get; private set; }
        public double IncludingTaxPrice { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyList<OrderItem> OrderItems => _orderItems;

        protected Order()
        {
            _orderItems = new List<OrderItem>();
            StatusId = EnumStatus.Active.Id;
        }

        private Order(
            int customerId,
            List<OrderItem> orderItems = default)
        {
            CustomerId = customerId;

            if (orderItems != default)
                _orderItems = orderItems;

            StatusId = EnumStatus.Active.Id;
        }

        public static Order Create(
            int customerId,
            List<OrderItem> orderItems = default)
        {
            return new Order(customerId, orderItems);
        }
    }
}
