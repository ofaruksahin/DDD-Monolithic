namespace EShop.Application.Commands.CustomerCommands
{
    public class DeleteCustomerAddressCommand : IRequest<BaseResponse<bool>>
    {
        public int CustomerId { get; private set; }
        public int AddressId { get; private set; }

        public DeleteCustomerAddressCommand(int customerId, int addressId)
        {
            CustomerId = customerId;
            AddressId = addressId;
        }
    }

    public class DeleteCustomerAddressCommandHandler : BaseCustomerCommand, IRequestHandler<DeleteCustomerAddressCommand, BaseResponse<bool>>
    {
        public DeleteCustomerAddressCommandHandler(ICustomerRepository customerRepository) : base(customerRepository)
        {
        }

        public async Task<BaseResponse<bool>> Handle(DeleteCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var exists = await _customerRepository.GetCustomerById(request.CustomerId);
            if (exists == null)
                return BaseResponse<bool>.Fail(false, "Böyle bir müşteri bulunamadı");

            var address = exists.CustomerAddresses.FirstOrDefault(f => f.Id == request.AddressId);
            if (address == null)
                return BaseResponse<bool>.Fail(false, "Böyle bir adres bulunamadı");
            address.ChangeStatusToPassive();
            _customerRepository.UpdateAddress(address);

            var result = await _customerRepository.UnitOfWork.SaveEntitiesAsync();
            if (!result)
                return BaseResponse<bool>.Fail(false, "Adres pasife alınamadı");
            return BaseResponse<bool>.Success(true);
        }
    }
}

