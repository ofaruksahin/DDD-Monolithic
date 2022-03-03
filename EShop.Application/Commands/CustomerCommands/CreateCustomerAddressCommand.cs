namespace EShop.Application.Commands.CustomerCommands
{
    public class CreateCustomerAddressCommand : CreateCustomerAddressDto, IRequest<BaseResponse<int>>
    {
        public int CustomerId { get; set; }
    }

    public class CreateCustomerAddressCommandHandler : BaseCustomerCommand, IRequestHandler<CreateCustomerAddressCommand, BaseResponse<int>>
    {
        public CreateCustomerAddressCommandHandler(ICustomerRepository customerRepository) : base(customerRepository)
        {
        }

        public async Task<BaseResponse<int>> Handle(CreateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var exists = await _customerRepository.GetCustomerById(request.CustomerId);
            if (exists == null)
                return BaseResponse<int>.Fail(0, "Böyle bir müşteri bulunamadı");

            var address = CustomerAddress.Create(
                request.Title,
                request.City,
                request.District,
                request.Neighborhood,
                request.Description
                );

            try
            {
                exists.AddAddress(address);
                _customerRepository.Update(exists);

                var result = await _customerRepository.UnitOfWork.SaveEntitiesAsync();
                if (!result)
                    return BaseResponse<int>.Fail(0, "Yeni adres tanımlanamadı");
                return BaseResponse<int>.Success(address.Id);
            }
            catch (CustomerAddressAlreadyDefinedException addressExp)
            {
                return BaseResponse<int>.Fail(0, addressExp.Message);
            }
        }
    }
}

