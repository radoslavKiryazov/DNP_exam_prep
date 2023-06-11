using Shared;

namespace Blazor.Clients;

public interface IDisplayClient
{
    Task<ICollection<Image>> GetImagesAsync(string albumCreator, string topic);
}