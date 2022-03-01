namespace EShop.Application.Commands.CustomerCommands
{
    public class CreateCustomerCommand : CreateCustomerDto, IRequest<BaseResponse<int>>
    {
    }

    public class CreateCustomerCommandHandler : BaseCustomerCommand, IRequestHandler<CreateCustomerCommand, BaseResponse<int>>
    {
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
            : base(customerRepository)
        {
        }

        public async Task<BaseResponse<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var existsEmail = await _customerRepository.FindByEmail(request.Email);

            if (existsEmail != null)
                return BaseResponse<int>.Fail(0, "Böyle bir email adresi zaten mevcut");

            Customer customer = Customer.CreateCustomer(
                request.Name,
                request.Surname,
                request.Email,
                request.BirthDate);

            foreach (var addressDto in request.Addresses)
            {
                CustomerAddress address = CustomerAddress.Create(
                       addressDto.Title,
                       addressDto.City,
                       addressDto.District,
                       addressDto.Neighborhood,
                       addressDto.Description
                    );

                customer.AddAddress(address);
            }

            _customerRepository.Add(customer);

            var result = await _customerRepository.UnitOfWork.SaveEntitiesAsync();

            if (!result)
                return BaseResponse<int>.Fail(0, "Müşteri oluşturulamadı");

            return BaseResponse<int>.Success(customer.Id);
        }
    }
}

