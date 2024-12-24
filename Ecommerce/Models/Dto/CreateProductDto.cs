namespace Ecommerce.Models.Dto;

public class CreateProductDto
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required int Quantity { get; set; }

    public string? Description { get; set; }
}
