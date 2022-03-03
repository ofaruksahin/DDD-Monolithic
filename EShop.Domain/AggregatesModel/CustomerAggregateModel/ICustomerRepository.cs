namespace EShop.Domain.AggregatesModel.CustomerAggregateModel
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> FindByEmail(string email);
        Customer Add(Customer customer);
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Customer Update(Customer customer);
        CustomerAddress UpdateAddress(CustomerAddress customerAddress);
    }
}

