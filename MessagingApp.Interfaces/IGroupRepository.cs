using System.Text.RegularExpressions;

namespace MessagingApp.Interfaces;

public interface IGroupRepository
{
    Task Create(Group group);
    Task Update(Group group);
    Task Delete(Group group);
}
