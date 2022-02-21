namespace EShop.Domain.AggregatesModel.SellerAggregateModel.Rules
{
    public class SellerCreatableRule : AbstractValidator<Seller>
    {
        public SellerCreatableRule()
        {
            RuleFor(f => f.Name)
                .MaximumLength(50)
                .WithMessage("Mağaza adı 50 karakterden fazla olamaz");
        }
    }
}

