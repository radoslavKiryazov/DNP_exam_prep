using System.Net.Http.Json;
using System.Text.Json;
using Shared;

namespace Blazor.Clients;

public class ChildService : IChildService
{
    private HttpClient _client;

    public ChildService(HttpClient client)
    {
        _client = client;
    }


    public async Task<Child> CreateChild(Child child)
    {
        HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("/Child", child);
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        Child created = JsonSerializer.Deserialize<Child>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return created;
    }

    public async Task<ICollection<string>> GetAllChildren()
    {
        HttpResponseMessage responseMessage = await _client.GetAsync("/Child");
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        var names = JsonSerializer.Deserialize<ICollection<string>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return names;
    }
}