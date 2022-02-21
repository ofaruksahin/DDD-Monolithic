namespace EShop.Domain.AggregatesModel.CategoryAggregateModel.Rules
{
    public class CategoryCreatableRule : AbstractValidator<Category>
    {
        public CategoryCreatableRule()
        {
            RuleFor(f => f.Name)
                .MaximumLength(50)
                .WithMessage("Kategori adı 50 karakterden fazla olamaz");
        }
    }
}

