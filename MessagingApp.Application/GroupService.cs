using MessagingApp.Contracts;
using MessagingApp.Interfaces;

namespace MessagingApp.Application;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRespositoty;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRespositoty = groupRepository;
    }

    public async Task<bool> CreateGroup(GroupDto groupDto)
    {
        if (groupDto is null || groupDto.Name is null)
        {
            return false;
        }

        await _groupRespositoty.Create(groupDto);

        return true;
    }
}
