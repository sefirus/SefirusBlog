using Core.Interfaces;

namespace Core.Entities;

public class Article : ICreatableEntity
{
    public Guid Id { get; set; }
    public User Author { get; set; }
    public Guid AuthorId { get; set; }
    public Commit BaseCommit { get; set; }
    public Guid BaseCommitId { get; set; }
    public Commit? PublishedCommit { get; set; }
    public Guid? PublishedCommitId { get; set; }
    public bool IsPublished { get; set; }
    public List<Commit> Commits { get; set; } = new List<Commit>();
    public DateTime CreatedDate { get; set; }
}