namespace EShop.Application.Dtos.BasketDtos
{
    public class BasketItemDto
    {
        public int ProductId { get; set; }
        public string SellerName { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public double ExcludesTaxPrice { get; set; }
        public double Tax { get; set; }
        public double IncludingTaxPrice { get; set; }
    }
}

