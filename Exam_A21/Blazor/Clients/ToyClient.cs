using System.Net.Http.Json;
using System.Text.Json;
using Shared;

namespace Blazor.Clients;

public class ToyClient : IToyClient
{
    private HttpClient _client;

    public ToyClient(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<Toy> CreateToy(Toy toy, string Owner)
    {
        HttpResponseMessage responseMessage = await _client.PostAsJsonAsync($"/owner/{Owner}",toy);
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        Toy created = JsonSerializer.Deserialize<Toy>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return created;
    }

    public async Task<ICollection<Toy>> GetAllToys(bool? isfavourite, string? gender)
    {
        var query = ConstructQuery(isfavourite, gender); 
        HttpResponseMessage responseMessage = await _client.GetAsync("/Toy"+query);
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        ICollection<Toy> toys = JsonSerializer.Deserialize<ICollection<Toy>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return toys;
    }

    public async Task DeleteToy(string toyName){
        var response = await _client.DeleteAsync($"/toyName/{toyName}");
        var result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) throw new Exception(result);
    }

    private static string ConstructQuery(bool? isfavourite, string? gender)
    {
        string query = "";
        if (isfavourite != null)
        {
            query += $"?isfavourite={isfavourite}";
        }
        if (!string.IsNullOrEmpty(gender))
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"gender={gender}";
        }

        Console.WriteLine($"QUERY:{query}");

        return query;
    }
}