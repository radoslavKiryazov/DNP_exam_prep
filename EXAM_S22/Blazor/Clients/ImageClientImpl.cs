using System.Net.Http.Json;
using System.Text.Json;
using Shared;

namespace Blazor.Clients;

public class ImageClientImpl : IImageClient
{
    private HttpClient client;

    public ImageClientImpl(HttpClient client)
    {
        this.client = client;
    }

    public async Task AddImageToAlbumAsync(Image img)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/Image", img);
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }

    public async Task<ICollection<string>> GetAlbumTitlesAsync()
    {
        HttpResponseMessage responseMessage = await client.GetAsync("/titles");
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        ICollection<string> titles = JsonSerializer.Deserialize<ICollection<string>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        Console.WriteLine(titles.Count);
        return titles;
    }
}