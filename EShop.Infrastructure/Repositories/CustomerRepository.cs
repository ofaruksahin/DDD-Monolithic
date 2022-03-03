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
            return await dbContext
                .Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Email == email);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await dbContext
                .Customers
                .Include(f => f.CustomerAddresses)
                .Include(f => f.Status)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await dbContext
                .Customers
                .Include(f => f.CustomerAddresses)
                .Include(f => f.Status)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public Customer Update(Customer customer)
        {
            return dbContext.Update(customer).Entity;
        }

        public CustomerAddress UpdateAddress(CustomerAddress customerAddress)
        {
            dbContext.Entry(customerAddress).State = EntityState.Modified;
            return customerAddress;
        }
    }
}

