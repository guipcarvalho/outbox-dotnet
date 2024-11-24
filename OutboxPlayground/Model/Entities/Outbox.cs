namespace Ordering.Model.Entities;

public class Outbox
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Action { get; set; }
    public DateTime EventDate { get; set; } = DateTime.UtcNow;
    public string Payload { get; set; }
}