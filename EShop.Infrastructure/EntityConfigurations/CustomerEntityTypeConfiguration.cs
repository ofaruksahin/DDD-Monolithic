namespace EShop.Infrastructure.EntityConfigurations
{
    public class CustomerEntityTypeConfiguration : BaseEntityTypeConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder
                 .Property(f => f.Name)
                 .HasMaxLength(50)
                 .IsRequired();

            builder
                .Property(f => f.Surname)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(f => f.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(f => f.BirthDate)
                .IsRequired();

            var customerAddress =
                  builder
                     .Metadata
                     .FindNavigation(nameof(Customer.CustomerAddresses));

            customerAddress
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}

