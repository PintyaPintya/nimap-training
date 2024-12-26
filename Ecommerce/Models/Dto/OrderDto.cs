using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models.Dto;

public class OrderDto
{
    [Required]
    public int CustomerId { get; set; }

    public ICollection<OrderProductDto> Products { get; set; } = new List<OrderProductDto>();
}