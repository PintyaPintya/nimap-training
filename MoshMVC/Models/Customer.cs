using System.ComponentModel.DataAnnotations;

namespace MoshMVC.Models;

public class Customer
{
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public required string Name { get; set; }

    [Required]
    [EmailAddress]
    public required string EmailAddress { get; set; }

    [Required]
    [StringLength(255)]
    public required string Password { get; set; }

    [Display(Name = "Date of Birth")]
    [Min18YrsIfAMember]
    public DateOnly? BirthDate { get; set; }
    
    public bool isSubscribedToNewsLetter { get; set; }

    [Required]
    [Display(Name = "Membership Type")]
    public byte MembershipTypeId { get; set; }
    public MembershipType? MembershipType { get; set; }
}