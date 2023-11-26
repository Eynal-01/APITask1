using APITask1.Entities;

namespace APITask1.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string? OrderDate { get; set; }
        public string? OrderName { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
