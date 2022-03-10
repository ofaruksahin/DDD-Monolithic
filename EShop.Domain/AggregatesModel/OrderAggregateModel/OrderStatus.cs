namespace EShop.Domain.AggregatesModel.OrderAggregateModel
{
    public class OrderStatus : Enumeration
    {
        public static OrderStatus WaitingPayment = new OrderStatus(1, "Ödeme bekliyor");
        public static OrderStatus OrderPreparation = new OrderStatus(2, "Sipariş Hazırlanıyor");
        public OrderStatus(int id, string name) : base(id, name)
        {
        }
    }
}
