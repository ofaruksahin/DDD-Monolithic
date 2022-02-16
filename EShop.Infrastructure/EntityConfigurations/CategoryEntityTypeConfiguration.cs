namespace EShop.Infrastructure.EntityConfigurations
{
    public class CategoryEntityTypeConfiguration : BaseEntityTypeConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            base.Configure(builder);

            builder.Property(f => f.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}

