namespace EShop.Infrastructure.EntityConfigurations
{
    public class SellerEntityTypeConfiguration
         : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Ignore(f => f.DomainEvents);

            builder.Property(f => f.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}