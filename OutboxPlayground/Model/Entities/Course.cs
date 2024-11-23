using System.ComponentModel.DataAnnotations;

namespace Ordering.Model.Entities;

public class Course : IAggregateRoot
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateUpdated { get; set; }
    
    public ICollection<Review> Reviews { get; set; }
}