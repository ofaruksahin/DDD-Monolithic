namespace EShop.Domain.AggregatesModel.CategoryAggregateModel
{
    public class Category : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        protected Category()
        {

        }

        public Category(string name)
        {
            Name = name;
            _statusId = EnumStatus.Active.Id;
        }

        public void SetStatusChangedToPassive()
        {
            _statusId = EnumStatus.Passive.Id;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }
    }
}

