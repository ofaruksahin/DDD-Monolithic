namespace EShop.Domain.AggregatesModel.CustomerAggregateModel
{
    public class CustomerAddress : Entity
    {
        public string Title { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string Description { get; set; }
    }
}

