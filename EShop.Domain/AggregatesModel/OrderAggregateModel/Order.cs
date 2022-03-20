using System.Runtime.CompilerServices;

namespace EShop.Domain.AggregatesModel.OrderAggregateModel
{
    public class Order : Entity, IAggregateRoot, INotification
    {
        public int CustomerId
        {
            get;
            private set;
        }

        public double ExcludesTaxPrice
        {
            get => OrderItems
                .Where(f => f.Status.Id == EnumStatus.Active.Id)
                .Sum(f => f.ExcludesTaxPrice * f.Count);
            private set { }
        }

        public double Tax
        {
            get => OrderItems
                .Where(f => f.Status.Id == EnumStatus.Active.Id)
                .Sum(f => f.Tax * f.Count);
            private set { }
        }

        public double IncludingTaxPrice
        {
            get => OrderItems
                .Where(f => f.Status.Id == EnumStatus.Active.Id)
                .Sum(f => f.IncludingTaxPrice * f.Count);
            private set { }
        }

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
            else
                _orderItems = new List<OrderItem>();

            StatusId = EnumStatus.Active.Id;
            AddDomainEvent(new OrderCreatedDomainEvent(this));
        }

        public static Order Create(
            int customerId,
            List<OrderItem> orderItems = default)
        {
            return new Order(customerId, orderItems);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            if (!OrderItems.Any(f => f.ProductId == orderItem.ProductId))
                _orderItems.Add(orderItem);
        }
    }
}
