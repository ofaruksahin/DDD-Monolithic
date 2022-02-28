namespace EShop.Domain.AggregatesModel.CustomerAggregateModel
{
    public class CustomerAddress : Entity
    {
        public string Title { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }
        public string Neighborhood { get; private set; }
        public string Description { get; private set; }

        protected CustomerAddress()
        {
        }

        private CustomerAddress(string title, string city, string district, string neighborhood, string description)
        {
            Title = title;
            City = city;
            District = district;
            Neighborhood = neighborhood;
            Description = description;

            _statusId = EnumStatus.Active.Id;
            AddDomainEvent(new CustomerAddressCreatedDomainEvent(this));
        }

        public static CustomerAddress Create(string title, string city, string district, string neighborhood, string description)
        {
            return new CustomerAddress(title, city, district, neighborhood, description);
        }

        public void ChangeStatusToPassive()
        {
            _statusId = EnumStatus.Passive.Id;
            AddDomainEvent(new CustomerAddressDeletedDomainEvent(this));
        }
    }
}

