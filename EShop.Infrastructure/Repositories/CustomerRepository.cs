namespace EShop.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(EShopDbContext dbContext) : base(dbContext)
        {
        }

        public IUnitOfWork UnitOfWork => dbContext;

        public Customer Add(Customer customer)
        {
            if (customer.IsTransient())
            {
                return dbContext.Customers.Add(customer).Entity;
            }
            return null;
        }

        public async Task<Customer> FindByEmail(string email)
        {
            return await dbContext.Customers.FirstOrDefaultAsync(f => f.Email == email);
        }
    }
}

