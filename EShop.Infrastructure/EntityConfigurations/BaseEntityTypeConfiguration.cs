namespace EShop.Infrastructure.EntityConfigurations
{
    public abstract class BaseEntityTypeConfiguration<T> :
        IEntityTypeConfiguration<T>
         where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Ignore(f => f.DomainEvents);

            builder.Property<int>("_statusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("StatusId")
                .IsRequired();

            builder.HasOne(f => f.Status)
                .WithMany()
                .HasForeignKey("_statusId");
        }
    }
}

