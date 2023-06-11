using Microsoft.AspNetCore.Mvc;
using Shared;
using WebAPI.Data;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GradesController: ControllerBase
{
    private readonly IDataAccess _dataAccess;

    public GradesController(IDataAccess _dataAccess)
    {
        this._dataAccess = _dataAccess;
    }
    
    [HttpGet("/{course}")]
    public async Task<ActionResult<StatisticsOverviewDTO>> GetAllStudentsAsync([FromRoute]string course)
    {
        try
        {
            StatisticsOverviewDTO dto = await _dataAccess.GetCourseStatisticsAsync(course);
            return Ok(dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}