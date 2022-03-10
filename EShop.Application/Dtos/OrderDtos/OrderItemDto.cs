namespace EShop.Application.Dtos.OrderDtos
{
    public class OrderItemDto
    {
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public double ExcludesTaxPrice { get; set; }
        public double Tax { get; set; }
        public double IncludingTaxPrice { get; set; }
        public string Status { get; set; }
    }
}
