using System.Text.Json.Serialization;

namespace Shared;

public class Student
{
    public int student_id { get; set; }
    public string Name { get; set; }
    public string Programme { get; set; }
    
    public ICollection<GradeInCourse>? grades { get; set; }
}