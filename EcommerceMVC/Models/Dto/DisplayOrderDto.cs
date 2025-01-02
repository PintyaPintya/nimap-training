namespace EcommerceMVC.Models.Dto;

public class DisplayOrderDto
{
    public Order Order { get; set; }
    public List<string> ProductNames { get; set; }
}