using Shared;

namespace Blazor.Clients;

public interface IImageClient
{
    Task AddImageToAlbumAsync(Image img);
    Task<ICollection<string>> GetAlbumTitlesAsync();
}