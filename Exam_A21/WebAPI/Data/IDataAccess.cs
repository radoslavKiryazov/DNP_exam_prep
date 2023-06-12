using Shared;

namespace WebAPI.Data;

public interface IDataAccess
{
    Task<Child> AddChildAsync(Child child);

    Task<ICollection<string>> GetAllChildren();

    Task<Toy> CreateToyAsync(Toy toy, string ChildName);
    Task<ICollection<Toy>> GetAllToys(bool? favourite, string? gender);

    Task DeleteToy(string toyName);
}