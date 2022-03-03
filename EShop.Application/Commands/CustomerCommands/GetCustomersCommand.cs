namespace EShop.Application.Commands.CustomerCommands
{
    public class GetCustomersCommand : IRequest<BaseResponse<List<CustomerDto>>>
    {
    }

    public class GetCustomersCommandHandler : BaseCustomerCommand, IRequestHandler<GetCustomersCommand, BaseResponse<List<CustomerDto>>>
    {
        public GetCustomersCommandHandler(ICustomerRepository customerRepository) : base(customerRepository)
        {
        }

        public async Task<BaseResponse<List<CustomerDto>>> Handle(GetCustomersCommand request, CancellationToken cancellationToken)
        {
            List<CustomerDto> response = new List<CustomerDto>();

            var customers = await _customerRepository.GetCustomers();

            customers.ForEach(customer =>
            {
                CustomerDto customerDto = new CustomerDto();
                customerDto.Id = customer.Id;
                customerDto.Name = customer.Name;
                customerDto.Surname = customer.Surname;
                customerDto.Email = customer.Email;
                customerDto.BirthDate = customer.BirthDate;
                customerDto.Status = customer.Status.Name;

                foreach (var customerAddress in customer.CustomerAddresses)
                {
                    CustomerAddressDto customerAddressDto = new CustomerAddressDto();
                    customerAddressDto.Id = customerAddress.Id;
                    customerAddressDto.Title = customerAddress.Title;
                    customerAddressDto.City = customerAddress.City;
                    customerAddressDto.District = customerAddress.District;
                    customerAddressDto.Neighborhood = customerAddress.Neighborhood;
                    customerAddressDto.Description = customerAddress.Description;
                    customerAddressDto.Status = customerAddress.Status.Name;
                    customerDto.CustomerAddresses.Add(customerAddressDto);
                }

                response.Add(customerDto);
            });

            return BaseResponse<List<CustomerDto>>.Success(response);
        }
    }
}

