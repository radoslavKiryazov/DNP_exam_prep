namespace Shared;

public class GradeInCourse
{
    
    public int Id { get; set; }
    public string CourseCode { get; set; }
    public int Grade { get; set; }
    
    public int? student_Id { get; set; }
    public Student? Student { get; set; }

}