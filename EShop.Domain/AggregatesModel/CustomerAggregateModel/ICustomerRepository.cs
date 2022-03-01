namespace EShop.Domain.AggregatesModel.CustomerAggregateModel
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> FindByEmail(string email);
        Customer Add(Customer customer);
    }
}

