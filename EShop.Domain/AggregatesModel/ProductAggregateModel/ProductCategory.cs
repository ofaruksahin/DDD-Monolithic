namespace EShop.Domain.AggregatesModel.ProductAggregateModel
{
    public class ProductCategory : Entity
    {
        public int CategoryId { get; private set; }

        protected ProductCategory()
        {

        }

        public ProductCategory(int categoryId)
        {
            CategoryId = categoryId;
            _statusId = EnumStatus.Active.Id;
        }
    }
}

