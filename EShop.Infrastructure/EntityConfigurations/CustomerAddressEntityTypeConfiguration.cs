namespace EShop.Infrastructure.EntityConfigurations
{
    public class CustomerAddressEntityTypeConfiguration : BaseEntityTypeConfiguration<CustomerAddress>
    {
        public override void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            base.Configure(builder);

            builder
                .Property(f => f.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(f => f.City)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(f => f.District)
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}

