using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models.Dto;

public class EditOrderDto
{
    [Required]
    public required string Status { get; set; }
}