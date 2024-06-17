using MessagingApp.Contracts;
using MessagingApp.Infrastructure.Entities;
using MessagingApp.Interfaces;

namespace MessagingApp.Infrastructure;

public class GroupRepository : IGroupRepository
{
    private readonly AppDbContext _context;

    public GroupRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(GroupDto group)
    {
        var groupEntity = new GroupEntity
        {
            Name = group.Name,
            CreatedAtUtc = DateTime.UtcNow
        };

        _context.Groups.Add(groupEntity);

        await _context.SaveChangesAsync();
    }
}
