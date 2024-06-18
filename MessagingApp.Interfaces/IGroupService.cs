using MessagingApp.Contracts;

namespace MessagingApp.Interfaces;

public interface IGroupService
{
    Task<List<GroupDto>> GetAllGroups();
    Task<GroupDto> GetGroupById(int id);
    Task<GroupDto> GetGroupByName(string groupName);
    Task<bool> CreateGroup(GroupDto groupDto);
    Task<bool> UpdateGroup(int id, GroupDto groupDto);
    Task<bool> DeleteGroupById(int id);
    Task<bool> DeleteGroupByName(string name);
}
