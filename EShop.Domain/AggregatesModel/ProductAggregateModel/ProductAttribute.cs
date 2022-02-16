namespace EShop.Domain.AggregatesModel.ProductAggregateModel
{
    public class ProductAttribute : Entity
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        public ProductAttribute(string name, string value)
        {
            Name = name;
            Value = value;
            _statusId = EnumStatus.Active.Id;
        }
    }
}

