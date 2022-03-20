namespace EShop.Application.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public int CustomerId { get; private set; }

        public CreateOrderDto(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
