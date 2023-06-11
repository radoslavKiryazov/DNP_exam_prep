using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Shared;

namespace WebAPI.Data;

public class DataAccess : IDataAccess
{
    private readonly StudentContext context;


    public DataAccess(StudentContext context)
    {
        this.context = context;
    }

    public async Task<Student> CreateStudentAsync(Student student)
    {
        EntityEntry<Student> newStudent = await context.AddAsync(student);
        await context.SaveChangesAsync();
        return newStudent.Entity;
    }

    public async Task<ICollection<Student>> GetAllStudents()
    {
        ICollection<Student> result = new List<Student>(await context.Students.ToListAsync());
        return result;
    }

    public async Task AddGradeToStudentAsync(GradeInCourse grade, int studentId)
    {

        await context.AddAsync(grade);
        await context.SaveChangesAsync();

    }

    public Task<StatisticsOverviewDTO> GetCourseStatisticsAsync(string? Course)
    {
        //Total Number Of students in course
        int totalStudents = context.Grades
            .Where(g => g.CourseCode.Equals(Course))
            .Select(g => g.student_Id)
            .Distinct()
            .Count();

        // Average grade of all students in a course
        double averageGradeAllStudents = context.Grades
            .Where(g => g.CourseCode.Equals(Course))
            .Average(g => g.Grade);

        // Average grade of students who have a passing grade
        double averageGradeOfAllPassingStudents = context.Grades
            .Where(g => g.CourseCode.Equals(Course) && g.Grade >= 2)
            .Average(g => g.Grade);

        //Number of students with passing grade
        int numberOfStudentsWithPassingGrade = context.Grades
            .Where(g => g.CourseCode.Equals(Course) && g.Grade >= 2)
            .Select(g => g.student_Id)
            .Distinct()
            .Count();


        //Median of All Grades
        var grades = context.Grades.Select(g => g.Grade); //get the grades column from the table.
        List<int> listGrades = grades.ToList(); // convert it into list
        listGrades.Sort(); // sort it

        int median = 0;
        
        if (listGrades.Count % 2 == 0) {
            median = listGrades.ElementAt(listGrades.Count / 2);
        }
        else
        {
            median = listGrades.ElementAt(listGrades.Count / 2 + 1);
        }

        StatisticsOverviewDTO dto = new StatisticsOverviewDTO
        {
            AvgGradeOfPassed = (float)averageGradeOfAllPassingStudents,
            AvgGradeOverall = (float)averageGradeAllStudents,
            CourseCode = Course,
            MedianGrade = median,
            TotalNumOfPassedStudents = numberOfStudentsWithPassingGrade,
            TotalNumOfStudents = totalStudents
        };

        return Task.FromResult(dto);

    }
}