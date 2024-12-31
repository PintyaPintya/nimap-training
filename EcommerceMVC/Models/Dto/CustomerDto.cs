using System.ComponentModel.DataAnnotations;

namespace EcommerceMVC.Models.Dto;

public class CustomerDto
{
    [Required(ErrorMessage = "Username is required.")]
    public required string Username { get; set; }

    public string? Role { get; set; }

    public string? Name { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email address")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    public required string Address { get; set; }
}