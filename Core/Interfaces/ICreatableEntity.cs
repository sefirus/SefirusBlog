namespace Core.Interfaces;

public interface ICreatableEntity
{
    Guid Id { get; set; }
    DateTime CreatedDate { get; set; }
}