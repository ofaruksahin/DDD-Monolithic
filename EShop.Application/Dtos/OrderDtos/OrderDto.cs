namespace EShop.Application.Dtos.OrderDtos
{
    public class OrderDto
    {
        public int CustomerId { get; set; }
        public double ExcludesTaxPrice { get; set; }
        public double Tax { get; set; }
        public double IncludingTaxPrice { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public string Status { get; set; }

        public OrderDto()
        {
            OrderItems = new List<OrderItemDto>();
        }
    }
}
