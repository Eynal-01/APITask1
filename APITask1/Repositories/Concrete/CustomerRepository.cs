using APITask1.Data;
using APITask1.Entities;
using APITask1.Repositories.Abstract;

namespace APITask1.Repositories.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ProductDbContext _context;

        public CustomerRepository(ProductDbContext context)
        {
            _context = context;
        }

        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            _context.Customers.Remove(entity);  
            _context.SaveChanges(); 
        }

        public Customer Get(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            var customers = _context.Customers;
            return customers;
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);  
            _context.SaveChanges(); 
        }
    }
}
