namespace EShop.Infrastructure.EntityConfigurations
{
    public class ProductCategoryEntityTypeConfiguration : BaseEntityTypeConfiguration<ProductCategory>
    {
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            base.Configure(builder);

            builder
                .Property<int>("ProductId")
                .IsRequired();

            builder
                .HasOne<Category>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("CategoryId");
        }
    }
}

