using System.Text.Json.Serialization;

namespace Trial.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
    }
}
