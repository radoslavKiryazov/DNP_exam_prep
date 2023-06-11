using Shared;

namespace WebAPI.Data;

public interface IDataAccess
{
    Task<Student> CreateStudentAsync(Student student);
    Task<ICollection<Student>> GetAllStudents();
    Task AddGradeToStudentAsync(GradeInCourse grade, int studentId);
    Task<StatisticsOverviewDTO> GetCourseStatisticsAsync(string? Course);
}