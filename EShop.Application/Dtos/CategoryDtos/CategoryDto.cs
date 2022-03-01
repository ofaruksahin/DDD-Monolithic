namespace EShop.Application.Dtos.CategoryDtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public CategoryDto(int id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }
    }
}

