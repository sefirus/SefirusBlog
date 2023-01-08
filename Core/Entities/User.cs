namespace Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsActive { get; set; } = true;
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedAt { get; set; }
}