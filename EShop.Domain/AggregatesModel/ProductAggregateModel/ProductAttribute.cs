namespace EShop.Domain.AggregatesModel.ProductAggregateModel
{
    public class ProductAttribute : Entity
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        protected ProductAttribute()
        {

        }

        private ProductAttribute(string name, string value)
        {
            Name = name;
            Value = value;
            _statusId = EnumStatus.Active.Id;

            CheckRule(new ProductAttributeCreatableRule());
        }

        public static ProductAttribute Create(string name, string value)
        {
            return new ProductAttribute(name, value);
        }
    }
}

