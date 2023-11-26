namespace APITask1.Entities
{
    public class Order
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
