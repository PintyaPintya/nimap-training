namespace Trial.Models
{
    public class AddOrUpdateProductDto
    {
        public required string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
