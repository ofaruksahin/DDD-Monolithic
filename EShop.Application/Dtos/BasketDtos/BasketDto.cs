namespace EShop.Application.Dtos.BasketDtos
{
    public class BasketDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public double ExcludesTaxPrice { get; set; }
        public double Tax { get; set; }
        public double IncludingTaxPrice { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }

        public BasketDto()
        {
            BasketItems = new List<BasketItemDto>();
        }
    }
}

