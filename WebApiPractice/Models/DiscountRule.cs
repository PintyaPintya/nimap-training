using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiPractice.Models;

public class DiscountRule
{
    public int DiscountRuleId { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal MinimumPrice { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal MaximumDiscount { get; set; }
}
