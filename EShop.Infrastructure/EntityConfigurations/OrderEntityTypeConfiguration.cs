namespace EShop.Infrastructure.EntityConfigurations
{
    public class OrderEntityTypeConfiguration : BaseEntityTypeConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            var orderItem = builder.Metadata.FindNavigation(nameof(Order.OrderItems));
            orderItem.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
