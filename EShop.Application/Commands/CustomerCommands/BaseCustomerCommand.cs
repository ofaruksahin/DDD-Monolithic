namespace EShop.Application.Commands.CustomerCommands
{
    public class BaseCustomerCommand
    {
        protected ICustomerRepository _customerRepository;

        public BaseCustomerCommand(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }
    }
}

