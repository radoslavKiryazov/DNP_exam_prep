using Shared;

namespace Blazor.Clients;

public interface IAlbumClient
{
    Task<Album> CreateAlbumAsync(Album album);
    
}