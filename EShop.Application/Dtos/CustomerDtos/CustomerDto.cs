namespace EShop.Application.Dtos.CustomerDtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Status { get; set; }

        public List<CustomerAddressDto> CustomerAddresses { get; set; }

        public CustomerDto()
        {
            CustomerAddresses = new List<CustomerAddressDto>();
        }
    }
}

