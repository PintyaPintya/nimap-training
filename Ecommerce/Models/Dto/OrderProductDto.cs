using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models.Dto;

public class OrderProductDto
{
    [Required]
    [Range(1,int.MaxValue)]
    public int ProductId { get; set; }

    [Required]
    [Range(1,int.MaxValue)]
    public int Quantity { get; set; }
}