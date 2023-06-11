using Microsoft.AspNetCore.Mvc;
using Shared;
using WebAPI.Data;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{
    private IDataAccess _dataAccess;

    public ImageController(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Image>>> GetImages([FromQuery]string? albumCreator,[FromQuery] string? topic)
    {
        Console.WriteLine(albumCreator);
        Console.WriteLine(topic);
        try
        {
            ICollection<Image> images = await _dataAccess.GetImagesAsync(albumCreator,topic);
            return Ok(images);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}