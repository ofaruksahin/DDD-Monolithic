using EShop.Domain.AggregatesModel.CategoryAggregateModel.Rules;

namespace EShop.Domain.AggregatesModel.CategoryAggregateModel
{
    public class Category : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        protected Category()
        {

        }

        private Category(string name)
        {
            Name = name;
            _statusId = EnumStatus.Active.Id;

            CheckRule(new CategoryCreatableRule());
        }

        public static Category Create(string name)
        {
            return new Category(name);
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

