using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Shared;

namespace Blazor.Clients;

public class AlbumClientImpl : IAlbumClient
{
    private HttpClient client;

    public AlbumClientImpl(HttpClient client)
    {
        this.client = client;
    }


    public async Task<Album> CreateAlbumAsync(Album album)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/Album", album);
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        Album created = JsonSerializer.Deserialize<Album>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return created;
    }
}