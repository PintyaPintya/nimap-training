namespace Ecommerce.Models.Dto;

public class EditProductDto
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required int Quantity { get; set; }
    public string? Description { get; set; }
    public bool IsDeleted { get; set; } = false;
}
