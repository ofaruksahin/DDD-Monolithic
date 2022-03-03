namespace EShop.Application.Commands.CustomerCommands
{
    public class GetCustomerCommand : IRequest<BaseResponse<CustomerDto>>
    {
        public int Id { get; private set; }

        public GetCustomerCommand(int id)
        {
            Id = id;
        }
    }

    public class GetCustomerCommandHandler : BaseCustomerCommand, IRequestHandler<GetCustomerCommand, BaseResponse<CustomerDto>>
    {
        public GetCustomerCommandHandler(ICustomerRepository customerRepository) : base(customerRepository)
        {
        }

        public async Task<BaseResponse<CustomerDto>> Handle(GetCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.Id);
            if (customer == null)
                return BaseResponse<CustomerDto>.Fail(null, "Böyle bir müşteri bulunamadı");

            CustomerDto customerDto = new CustomerDto();
            customerDto.Id = customer.Id;
            customerDto.Name = customer.Name;
            customerDto.Surname = customer.Surname;
            customerDto.Email = customer.Email;
            customerDto.BirthDate = customer.BirthDate;
            customerDto.Status = customer.Status.Name;

            foreach (var address in customer.CustomerAddresses)
            {
                CustomerAddressDto addressDto = new CustomerAddressDto();
                addressDto.Id = address.Id;
                addressDto.Title = address.Title;
                addressDto.District = address.District;
                addressDto.Neighborhood = address.Neighborhood;
                addressDto.Description = address.Description;
                addressDto.Status = address.Status.Name;

                customerDto.CustomerAddresses.Add(addressDto);
            }

            return BaseResponse<CustomerDto>.Success(customerDto);
        }
    }
}

