namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsSubscribed { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}
