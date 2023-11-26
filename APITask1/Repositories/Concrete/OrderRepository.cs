using APITask1.Data;
using APITask1.Entities;
using APITask1.Repositories.Abstract;

namespace APITask1.Repositories.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProductDbContext _context;

        public OrderRepository(ProductDbContext context)
        {
            _context = context;
        }

        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Order entity)
        {
            _context.Orders.Remove(entity);
            _context.SaveChanges();
        }

        public Order Get(int id)
        {
            var order = _context.Orders.SingleOrDefault(o => o.Id == id);
            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _context.Orders;
            return orders;
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
            _context.SaveChanges();
        }
    }
}
