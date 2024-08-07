namespace Domain.Entities
{
    public class Product : NoSQLBaseEntity
    {
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
