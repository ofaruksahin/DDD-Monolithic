namespace EShop.Infrastructure.EntityConfigurations
{
    public class ProductAttributeEntityTypeConfiguration : BaseEntityTypeConfiguration<ProductAttribute>
    {
        public override void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            base.Configure(builder);

            builder
                .Property(f => f.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(f => f.Value)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property<int>("ProductId")
                .IsRequired();
        }
    }
}

