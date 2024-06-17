namespace MessagingApp.Infrastructure.Entities;

public record GroupEntity
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required DateTime CreatedAtUtc { get; set; }
}
