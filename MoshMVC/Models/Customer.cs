using System.ComponentModel.DataAnnotations;

namespace MoshMVC.Models;

public class Customer
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public DateOnly? BirthDate { get; set; }

    public bool isSubscribedToNewsLetter { get; set; }
    public byte MembershipTypeId { get; set; }
    public MembershipType? MembershipType { get; set; }
}