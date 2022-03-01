namespace EShop.Domain.AggregatesModel.ProductAggregateModel
{
    public class Product : Entity, IAggregateRoot
    {
        public int SellerId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; private set; }

        private readonly List<ProductCategory> _categories;
        public IReadOnlyList<ProductCategory> Categories => _categories;

        private readonly List<ProductAttribute> _attributes;
        public IReadOnlyList<ProductAttribute> Attributes => _attributes;

        protected Product()
        {
            _attributes = new List<ProductAttribute>();
            _categories = new List<ProductCategory>();
        }

        private Product(
            string name,
            string description,
            int quantity,
            double price,
            int sellerId)
        {
            _attributes = new List<ProductAttribute>();
            _categories = new List<ProductCategory>();

            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
            SellerId = sellerId;

            _statusId = EnumStatus.Active.Id;
            AddDomainEvent(new ProductCreatedDomainEvent(this));

            CheckRule(new ProductCreatableRule());
        }

        public static Product Create(
            string name,
            string description,
            int quantity,
            double price,
            int sellerId
            )
        {
            return new Product(name, description, quantity, price, sellerId);
        }

        public void AddAttribute(ProductAttribute attribute)
        {
            _attributes.Add(attribute);
        }

        public void AddCategory(ProductCategory category)
        {
            _categories.Add(category);
        }

        public void ChangeStatusToPassive()
        {
            _statusId = EnumStatus.Passive.Id;

            AddDomainEvent(new ProductStatusChangedToPassive(this));
        }
    }
}