using Shared;

namespace BlazorWASM.Data;

public interface IStudentService
{
    public Task CreateAsync(Student student);
    public Task<ICollection<Student>> GetAllStudents();
    public Task AddGradeToStudent(GradeInCourse gradeInCourse, int studentId);
}