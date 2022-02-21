namespace EShop.Infrastructure.EntityConfigurations
{
    public class ProductEntityTypeConfiguration : BaseEntityTypeConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            base.Configure(builder);

            var attributeNavigation = builder.Metadata.FindNavigation(nameof(Product.Attributes));

            attributeNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var categoryNavigation = builder.Metadata.FindNavigation(nameof(Product.Categories));

            categoryNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne<Seller>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("SellerId");
        }
    }
}

