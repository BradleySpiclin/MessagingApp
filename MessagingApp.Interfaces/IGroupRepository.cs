using MessagingApp.Contracts;

namespace MessagingApp.Interfaces;

public interface IGroupRepository
{
    Task Create(GroupDto group);
    // Task Update(Group group);
    // Task Delete(Group group);
}
