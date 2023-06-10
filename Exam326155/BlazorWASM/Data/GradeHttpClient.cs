using System.Text.Json;
using Shared;

namespace BlazorWASM.Data;

public class GradeHttpClient : IGradeService
{
    private readonly HttpClient client;

    public GradeHttpClient(HttpClient client)
    {
        this.client = client;
    }
    public async Task<StatisticsOverviewDTO> GetCourseStatistics(string course)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"/{course}");
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        StatisticsOverviewDTO dto = JsonSerializer.Deserialize<StatisticsOverviewDTO>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return dto;
    }
}