using Core.Interfaces;

namespace Core.Entities;

public class User : ICreatableEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string? Nickname { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsActive { get; set; } = true;
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    public List<Article> Articles { get; set; } = new List<Article>();
    public DateTime CreatedDate { get; set; }
}