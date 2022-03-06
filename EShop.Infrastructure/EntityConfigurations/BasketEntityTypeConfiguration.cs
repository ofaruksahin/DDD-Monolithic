namespace EShop.Infrastructure.EntityConfigurations
{
    public class BasketEntityTypeConfiguration : BaseEntityTypeConfiguration<Basket>
    {
        public override void Configure(EntityTypeBuilder<Basket> builder)
        {
            base.Configure(builder);

            builder
                .Property(f => f.CustomerId)
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

            var basketItemNavigation = builder.Metadata.FindNavigation(nameof(Basket.BasketItems));
            basketItemNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne<BasketItem>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("BasketItem");
        }
    }
}

