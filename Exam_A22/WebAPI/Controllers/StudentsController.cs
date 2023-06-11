using Microsoft.AspNetCore.Mvc;
using Shared;
using WebAPI.Data;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IDataAccess _dataAccess;

    public StudentsController(IDataAccess _dataAccess)
    {
        this._dataAccess = _dataAccess;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(Student student)
    {
        try
        {
            Student temp = await _dataAccess.CreateStudentAsync(student);
            return Created($"/students/{temp.student_id}",temp);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Student>>> GetAllStudentsAsync()
    {
        try
        {
            ICollection<Student> students = await _dataAccess.GetAllStudents();
            return Ok(students);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("/grade")]
    public async Task<ActionResult> AddGradeToStudentAsync(GradeInCourse gradeInCourse)
    {
        try
        {
            await _dataAccess.AddGradeToStudentAsync(gradeInCourse,0);
            return Created($"/students/grade/{gradeInCourse.Id}",gradeInCourse);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}