using System;
using System.Collections.Generic;

namespace MessagingApp.Domain;

public record Group
{
    public required string Name { get; init; }

    public required DateTime CreatedAtUtc { get; init; }
}
