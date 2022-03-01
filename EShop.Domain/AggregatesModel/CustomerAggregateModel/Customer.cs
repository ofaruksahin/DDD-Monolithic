namespace EShop.Domain.AggregatesModel.CustomerAggregateModel
{
    public class Customer : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }

        private readonly List<CustomerAddress> _customerAddresses;
        public IReadOnlyList<CustomerAddress> CustomerAddresses => _customerAddresses;

        protected Customer()
        {
            _customerAddresses = new List<CustomerAddress>();
        }

        private Customer(string name, string surname, string email, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate;

            _statusId = EnumStatus.Active.Id;

            _customerAddresses = new List<CustomerAddress>();

            AddDomainEvent(new CustomerCreatedDomainEvent(this));

            CheckRule(new CustomerCreatableRule());
        }

        public static Customer CreateCustomer(string name, string surname, string email, DateTime birthDate)
        {
            return new Customer(name, surname, email, birthDate);
        }

        public void AddAddress(CustomerAddress customerAddress)
        {
            if (CustomerAddresses.Any(f => f.Title == customerAddress.Title))
                throw new CustomerAddressAlreadyDefinedException(customerAddress.Title);
            _customerAddresses.Add(customerAddress);
        }

        public void RemoveAddress(int id)
        {
            var address = CustomerAddresses.FirstOrDefault(f => f.Id == id);
            if (address == null)
                throw new CustomerAddressNotFoundException();
            address.ChangeStatusToPassive();
        }

        public void RemoveAddress(string title)
        {
            var address = CustomerAddresses.FirstOrDefault(f => f.Title == title);
            if (address == null)
                throw new CustomerAddressNotFoundException();
            address.ChangeStatusToPassive();
        }
    }
}

