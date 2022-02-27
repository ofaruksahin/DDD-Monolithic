namespace EShop.Domain.AggregatesModel.CustomerAggregateModel
{
    public class Customer : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}

