using MessagingApp.Contracts;

namespace MessagingApp.Interfaces;

public interface IGroupRepository
{
    Task<List<GroupDto>> GetAll();
    Task<GroupDto> Get(int id);
    Task<GroupDto> Get(string name);
    Task Create(GroupDto group);
    Task Update(int id, GroupDto group);
    Task Delete(int id);
    Task Delete(string name);
}
