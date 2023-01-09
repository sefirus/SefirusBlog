using Core.Interfaces;

namespace Core.Entities;

public class Commit : ICreatableEntity
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Article ParentArticle { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public Commit Parent { get; set; }
    public Guid ParentId { get; set; }
    public List<Commit> Children { get; set; } = new List<Commit>();
    public DateTime CreatedDate { get; set; }
    
    public Article PublishedArticle { get; set; }
    public Article BaseArticle { get; set; }
}