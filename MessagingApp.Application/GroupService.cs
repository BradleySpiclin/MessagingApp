using MessagingApp.Contracts;
using MessagingApp.Interfaces;

namespace MessagingApp.Application;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<bool> CreateGroup(GroupDto groupDto)
    {
        if (groupDto is null || string.IsNullOrEmpty(groupDto.Name))
        {
            return false;
        }

        await _groupRepository.Create(groupDto);

        return true;
    }
}
