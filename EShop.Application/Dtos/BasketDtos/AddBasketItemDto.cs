namespace EShop.Application.Dtos.BasketDtos
{
    public class AddBasketItemDto
    {
        public int SellerId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}

