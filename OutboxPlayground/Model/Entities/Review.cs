using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ordering.Model.Entities;

public class Review
{
    [Key]
    public int Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    
    public int CourseId { get; set; }
    
    [ForeignKey(nameof(CourseId))]
    [JsonIgnore]
    public Course? Course { get; set; }
}