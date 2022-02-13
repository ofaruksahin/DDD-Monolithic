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
    }
}

