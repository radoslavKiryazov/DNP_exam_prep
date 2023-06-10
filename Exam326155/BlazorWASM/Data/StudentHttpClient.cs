using System.Net.Http.Json;
using System.Text.Json;
using Shared;

namespace BlazorWASM.Data;

public class StudentHttpClient : IStudentService
{
    private readonly HttpClient client;

    public StudentHttpClient(HttpClient client)
    {
        this.client = client;
    }


    public async Task CreateAsync(Student student)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/Students",student);
        if (!responseMessage.IsSuccessStatusCode)
        {
            string content = await responseMessage.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<ICollection<Student>> GetAllStudents()
    {
        HttpResponseMessage responseMessage = await client.GetAsync("/Students");
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        ICollection<Student> students = JsonSerializer.Deserialize<ICollection<Student>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        Console.WriteLine(students.Count);
        return students;
    }

    public async Task AddGradeToStudent(GradeInCourse gradeInCourse, int studentId)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/grade",gradeInCourse);
        if (!responseMessage.IsSuccessStatusCode)
        {
            string content = await responseMessage.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
}