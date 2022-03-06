namespace EShop.Application.Dtos.BasketDtos
{
    public class CreateBasketDto
    {
        public int CustomerId { get; set; }
        public List<AddBasketItemDto> BasketItems { get; set; }

        public CreateBasketDto()
        {
            BasketItems = new List<AddBasketItemDto>();
        }
    }
}

