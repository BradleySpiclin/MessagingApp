using MessagingApp.Contracts;
using MessagingApp.Infrastructure.Entities;
using MessagingApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MessagingApp.Infrastructure;

public class GroupRepository : IGroupRepository
{
    private readonly AppDbContext _context;

    public GroupRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<GroupDto>> GetAll()
    {
        var groupEntities = await _context.Groups.ToListAsync();
        var groupDtos = new List<GroupDto>();

        foreach (var groupEntity in groupEntities)
        {
            GroupDto groupDto = new()
            {
                Name = groupEntity.Name,
            };

            groupDtos.Add(groupDto);
        }

        return groupDtos;
    }

    public async Task<GroupDto> Get(int id)
    {
        GroupEntity? groupEntity = await _context.Groups.FindAsync(id);

        GroupDto groupDto = new GroupDto
        { 
            Name = groupEntity.Name 
        };

        return groupDto;
    }

    public async Task<GroupDto> Get(string name)
    {
        GroupEntity? groupEntity = await _context.Groups.FirstOrDefaultAsync(g => g.Name == name); ;

        GroupDto groupDto = new()
        {
            Name = groupEntity.Name
        };

        return groupDto;
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

    public async Task Update(int id, GroupDto updatedGroup)
    {
        GroupEntity? existingGroup = await _context.Groups.FindAsync(id);

        existingGroup.Name = updatedGroup.Name;

        _context.Groups.Update(existingGroup);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        GroupEntity? groupEntity = await _context.Groups.FindAsync(id);

        _context.Groups.Remove(groupEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(string name)
    {
        GroupEntity? groupEntity = await _context.Groups.FirstOrDefaultAsync(g => g.Name == name);

        _context.Groups.Remove(groupEntity);

        await _context.SaveChangesAsync();
    }
}
