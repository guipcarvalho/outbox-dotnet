using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ordering.Model.Entities;

public class Review
{
    [Key]
    public Guid Id { get; set; }
    public int Rating { get; set; }
    [MaxLength(500)]
    public required string Comment { get; set; }
    
    public Guid CourseId { get; set; }
    
    [ForeignKey(nameof(CourseId))]
    [JsonIgnore]
    public Course? Course { get; set; }
}