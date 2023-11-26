using APITask1.Entities;
using APITask1.Repositories.Abstract;
using APITask1.Services.Abstract;

namespace APITask1.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Add(Customer entity)
        {
            _customerRepository.Add(entity);
        }

        public void Delete(int id)
        {
            var item = _customerRepository.Get(id);
            _customerRepository.Delete(item);
        }

        public Customer Get(int id)
        {
            return _customerRepository.Get(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public void Update(Customer entity)
        {
            _customerRepository.Update(entity);
        }
    }
}
