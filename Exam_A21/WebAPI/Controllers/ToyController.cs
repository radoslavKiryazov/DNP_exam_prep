using Microsoft.AspNetCore.Mvc;
using Shared;
using WebAPI.Data;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ToyController : ControllerBase
{
    private IDataAccess _dataAccess;
    
    public ToyController(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    
    [HttpPost("/owner/{owner}")]
    public async Task<ActionResult<Toy>> CreateChild(Toy toy, [FromRoute] string owner)
    {
        try
        {
            Toy added = await _dataAccess.CreateToyAsync(toy,owner);
            return Created($"/toy/{toy.Name}",added);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet] 
    public async Task<ActionResult<Toy>> GetAllToys([FromQuery]bool? isfavourite, [FromQuery] string? gender)
    {
        try
        {
            ICollection<Toy> toys = await _dataAccess.GetAllToys(isfavourite, gender);
            return Ok(toys);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    [HttpDelete("/toyName/{name}")]
    public async Task<ActionResult> DeleteToy([FromRoute] string name)
    {
        try
        {
            await _dataAccess.DeleteToy(name);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}