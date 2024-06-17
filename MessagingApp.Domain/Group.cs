using System;

namespace MessagingApp.Domain;

public record Group
{
    public required string Name { get; init; }

    public required DateTime CreatedAtUtc { get; init; }
}
