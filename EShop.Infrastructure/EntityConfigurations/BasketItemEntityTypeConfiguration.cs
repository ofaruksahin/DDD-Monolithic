namespace EShop.Infrastructure.EntityConfigurations
{
    public class BasketItemEntityTypeConfiguration : BaseEntityTypeConfiguration<BasketItem>
    {
        public override void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            base.Configure(builder);

            builder
                .Property(f => f.SellerId)
                .IsRequired();

            builder
                .Property(f => f.SellerName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(f => f.ProductId)
                .IsRequired();

            builder
                .Property(f => f.ProductName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(f => f.Count)
                .IsRequired();

            builder
                .Property(f => f.ExcludesTaxPrice)
                .IsRequired();

            builder
                .Property(f => f.Tax)
                .IsRequired();

            builder
                .Property(f => f.IncludingTaxPrice)
                .IsRequired();
        }
    }
}

