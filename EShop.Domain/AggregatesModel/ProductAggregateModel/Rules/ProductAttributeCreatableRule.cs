namespace EShop.Domain.AggregatesModel.ProductAggregateModel.Rules
{
    public class ProductAttributeCreatableRule : AbstractValidator<ProductAttribute>
    {
        public ProductAttributeCreatableRule()
        {
            RuleFor(f => f.Name)
                .MaximumLength(50)
                .WithMessage("Ürün özellik adı 50 karakterden fazla olamaz");

            RuleFor(f => f.Value)
                .MaximumLength(50)
                .WithMessage("Ürün özellik açıklaması 50 karakterden fazla olamaz");
        }
    }
}

