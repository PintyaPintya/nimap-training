namespace Crud.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Product> Products { get; set; } = [];
    }
}
