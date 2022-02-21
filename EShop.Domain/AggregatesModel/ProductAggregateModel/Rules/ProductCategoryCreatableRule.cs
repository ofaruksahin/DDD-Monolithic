namespace EShop.Domain.AggregatesModel.ProductAggregateModel.Rules
{
    public class ProductCategoryCreatableRule : AbstractValidator<ProductCategory>
    {
        public ProductCategoryCreatableRule()
        {
            RuleFor(f => f.CategoryId)
                .GreaterThan(0)
                .WithMessage("Lütfen geçerli bir kategori giriniz");
        }
    }
}

