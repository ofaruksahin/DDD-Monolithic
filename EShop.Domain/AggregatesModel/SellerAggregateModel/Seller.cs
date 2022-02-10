namespace EShop.Domain.AggregatesModel.SellerAggregateModel
{
    public class Seller : Entity, IAggregateRoot
    {
        public string Name
        {
            get;
            private set;
        }

        protected Seller()
        {
        }

        public Seller(string name)
        {
            Name = name;
            _statusId = EnumStatus.Active.Id;
        }

        public void AddSeller()
        {
            AddDomainEvent(new SellerCreatedDomainEvent(this));
        }

        public void SetStatusChangedToPassive()
        {
            _statusId = EnumStatus.Passive.Id;
            AddDomainEvent(new SellerStatusChangedToPassive(this));
        }
    }
}