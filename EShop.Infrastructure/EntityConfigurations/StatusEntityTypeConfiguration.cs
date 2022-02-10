namespace EShop.Infrastructure.EntityConfigurations
{
    public class StatusEntityTypeConfiguration
        : IEntityTypeConfiguration<EnumStatus>
    {
        public StatusEntityTypeConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<EnumStatus> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .Property(f => f.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                    EnumStatus.Passive,
                    EnumStatus.Active
                );
        }
    }
}

