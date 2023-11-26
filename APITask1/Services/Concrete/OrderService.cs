using APITask1.Entities;
using APITask1.Repositories.Abstract;
using APITask1.Services.Abstract;

namespace APITask1.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Add(Order entity)
        {
           _orderRepository.Add(entity);    
        }

        public void Delete(int id)
        {
            var item = _orderRepository.Get(id);
            _orderRepository.Delete(item);
        }

        public Order Get(int id)
        {
           return _orderRepository.Get(id); 
        }

        public IEnumerable<Order> GetAll()
        {
           return _orderRepository.GetAll();
        }

        public void Update(Order entity)
        {
            _orderRepository.Update(entity);
        }
    }
}
