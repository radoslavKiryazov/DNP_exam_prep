using System.Text.Json;
using Shared;

namespace Blazor.Clients;

public class DisplayClientImpl : IDisplayClient
{
    private HttpClient _client;

    public DisplayClientImpl(HttpClient _client)
    {
        this._client = _client;
    }


    public async Task<ICollection<Image>> GetImagesAsync(string albumCreator, string topic)
    {
        var query = ConstructQuery(albumCreator, topic);
        HttpResponseMessage responseMessage = await _client.GetAsync("/Image"+query);
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        ICollection<Image> images = JsonSerializer.Deserialize<ICollection<Image>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        Console.WriteLine(images.Count);
        return images;
    }
    private static string ConstructQuery(string? albumCreator, string? topic)
    {
        string query = "";
        if (!string.IsNullOrEmpty(albumCreator))
        {
            query += $"?albumCreator={albumCreator}";
        }
        if (!string.IsNullOrEmpty(topic))
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"topic={topic}";
        }

        Console.WriteLine(query);

        return query;
    }
}