namespace WebApiPractice.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public string? Email { get; set; }
    public List<string> Roles { get; set; } = new List<string>();
}
