namespace EShop.Infrastructure.EntityConfigurations
{
    public class SellerEntityTypeConfiguration : BaseEntityTypeConfiguration<Seller>
    {
        public override void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Sellers");
            base.Configure(builder);

            builder.Property(f => f.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}