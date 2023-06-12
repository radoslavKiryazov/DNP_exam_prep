using Shared;

namespace Blazor.Clients;

public interface IToyClient
{
    Task<Toy> CreateToy(Toy toy, string Owner);
    Task<ICollection<Toy>> GetAllToys(bool? isfavourite, string gender);
    Task DeleteToy(string toyName);
}