using APITask1.Data;
using APITask1.Entities;
using APITask1.Repositories.Abstract;

namespace APITask1.Repositories.Concrete
{
    public class ProductRepository:IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public void Add(Product entity)
        {
            _context.Products.Add(entity);  
            _context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges(); 
        }

        public Product Get(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _context.Products;
            return products;
        }

        public void Update(Product entity)
        {
           _context.Products.Update(entity);
            _context.SaveChanges();
        }
    }
}
