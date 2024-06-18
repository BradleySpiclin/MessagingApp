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

    public async Task<List<GroupDto>> GetAllGroups()
    {
        var groups = await _groupRepository.GetAll();

        if (groups == null)
        {
            return null;
        }

        return groups;
    }

    public async Task<GroupDto> GetGroupById(int id)
    {
        GroupDto group = await _groupRepository.Get(id);

        if (group == null)
        {
            return null;
        }

        return group;
    }

    public async Task<GroupDto> GetGroupByName(string name)
    {
        GroupDto group = await _groupRepository.Get(name);

        if (group == null)
        {
            return null;
        }

        return group;
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

    public async Task<bool> UpdateGroup(int id, GroupDto updatedGroup)
    {
        GroupDto groupToUpdate = await _groupRepository.Get(id);

        if (groupToUpdate == null || updatedGroup == null || string.IsNullOrEmpty(updatedGroup.Name))
        {
            return false;
        }

        await _groupRepository.Update(id, updatedGroup);

        return true;
    }

    public async Task<bool> DeleteGroupById(int id)
    {
        GroupDto group = await _groupRepository.Get(id);

        if (group  == null)
        {
            return false;
        }

        await _groupRepository.Delete(id);

        return true;
    }

    public async Task<bool> DeleteGroupByName(string name)
    {
        GroupDto group = await _groupRepository.Get(name);

        if (group == null)
        {
            return false;
        }

        await _groupRepository.Delete(name);

        return true;
    }
}
