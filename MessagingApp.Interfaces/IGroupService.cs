using MessagingApp.Contracts;

namespace MessagingApp.Interfaces;

public interface IGroupService
{
    Task<bool> CreateGroup(GroupDto groupDto);
}
