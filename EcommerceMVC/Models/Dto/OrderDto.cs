using System.ComponentModel.DataAnnotations;

namespace EcommerceMVC.Models.Dto;

public class OrderDto
{
     [Required]
    public int CustomerId { get; set; }

    public Customer? Customer { get; set; }

    [Required]
    public ICollection<Product> Products { get; set; } = new List<Product>();
}