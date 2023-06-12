using Shared;

namespace Blazor.Clients;

public interface IChildService
{
    Task<Child> CreateChild(Child child);

    Task<ICollection<string>> GetAllChildren();
}