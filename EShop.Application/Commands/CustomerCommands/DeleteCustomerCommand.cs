namespace EShop.Application.Commands.CustomerCommands
{
    public class DeleteCustomerCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; private set; }

        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteCustomerCommandHandler : BaseCustomerCommand, IRequestHandler<DeleteCustomerCommand, BaseResponse<bool>>
    {
        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository) : base(customerRepository)
        {
        }

        public async Task<BaseResponse<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var exists = await _customerRepository.GetCustomerById(request.Id);
            if (exists == null)
                return BaseResponse<bool>.Fail(false, "Böyle bir kullanıcı bulunamadı");
            exists.ChangeStatusToPassive();
            _customerRepository.Update(exists);

            var result = await _customerRepository.UnitOfWork.SaveEntitiesAsync();
            if (!result)
                return BaseResponse<bool>.Fail(false, "Müşteri pasif edilemedi");
            return BaseResponse<bool>.Success(true);
        }
    }
}

