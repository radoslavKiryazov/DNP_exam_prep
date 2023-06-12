using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;
using WebAPI.Data;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ChildController : ControllerBase
{
    private IDataAccess _dataAccess;

    public ChildController(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    [HttpPost]
    public async Task<ActionResult<Child>> CreateChild(Child child)
    {
        try
        {
            Child added = await _dataAccess.AddChildAsync(child);
            return Created($"/child/{added.Name}",added);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    public async Task<ActionResult<string>> GetAllChildren()
    {
        try
        {
            var result = await _dataAccess.GetAllChildren();
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}