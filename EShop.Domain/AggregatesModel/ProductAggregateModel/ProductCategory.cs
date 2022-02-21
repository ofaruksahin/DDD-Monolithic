namespace EShop.Domain.AggregatesModel.ProductAggregateModel
{
    public class ProductCategory : Entity
    {
        public int CategoryId { get; private set; }

        protected ProductCategory()
        {

        }

        private ProductCategory(int categoryId)
        {
            CategoryId = categoryId;
            _statusId = EnumStatus.Active.Id;

            CheckRule(new ProductCategoryCreatableRule());
        }

        public static ProductCategory Create(int categoryId)
        {
            return new ProductCategory(categoryId);
        }
    }
}

