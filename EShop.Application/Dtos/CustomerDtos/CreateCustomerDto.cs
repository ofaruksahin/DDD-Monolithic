namespace EShop.Application.Dtos.CustomerDtos
{
    public class CreateCustomerDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public List<CreateCustomerAddressDto> Addresses { get; set; }

        public CreateCustomerDto()
        {
            Addresses = new List<CreateCustomerAddressDto>();
        }
    }
}

