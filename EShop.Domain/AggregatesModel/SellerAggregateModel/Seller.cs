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

        private Seller(string name)
        {
            Name = name;
            _statusId = EnumStatus.Active.Id;

            CheckRule(new SellerCreatableRule());
        }

        public static Seller Create(string name)
        {
            return new Seller(name);
        }

        public void AddSeller()
        {
            AddDomainEvent(new SellerCreatedDomainEvent(this));
        }

        public void SetStatusChangedToPassive()
        {
            _statusId = EnumStatus.Passive.Id;
            AddDomainEvent(new SellerStatusChangedToPassiveDomainEvent(this));
        }
    }
}