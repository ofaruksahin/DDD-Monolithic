namespace EShop.Application.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }
        public List<int> CategoryIds { get; set; } = new List<int>();
        public List<CreateProductAttributeDto> Attributes { get; set; } = new List<CreateProductAttributeDto>();
    }
}

