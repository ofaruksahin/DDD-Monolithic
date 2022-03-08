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

            builder.Property(f => f.StatusId);

            builder.Ignore(f => f.Status);
        }
    }
}

