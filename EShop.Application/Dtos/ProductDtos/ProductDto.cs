namespace EShop.Application.Dtos.ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public List<ProductAttributeDto> Attributes { get; set; } = new List<ProductAttributeDto>();
        public List<ProductCategoryDto> Categories { get; set; } = new List<ProductCategoryDto>();
        public string Status { get; set; }
    }
}

