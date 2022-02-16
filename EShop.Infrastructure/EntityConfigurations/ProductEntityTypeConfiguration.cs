namespace EShop.Infrastructure.EntityConfigurations
{
    public class ProductEntityTypeConfiguration : BaseEntityTypeConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            base.Configure(builder);

            var navigation = builder.Metadata.FindNavigation(nameof(Product.Attributes));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne<Seller>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("SellerId");

            builder.HasOne<Category>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("CategoryId");
        }
    }
}

