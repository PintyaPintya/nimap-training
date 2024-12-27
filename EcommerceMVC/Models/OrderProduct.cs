using System.ComponentModel.DataAnnotations;

namespace EcommerceMVC.Models;

public class OrderProduct
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int OrderId { get; set; }

    public Order? Order { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    public Product? Product { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}
