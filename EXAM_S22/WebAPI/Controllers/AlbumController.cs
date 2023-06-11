using Microsoft.AspNetCore.Mvc;
using Shared;
using WebAPI.Data;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class AlbumController : ControllerBase
{
    private IDataAccess _dataAccess;

    public AlbumController(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    [HttpPost]
    public async Task<ActionResult<Album>> CreateAlbum(Album album)
    {
        try
        {
            Album temp = await _dataAccess.AddAlbumAsync(album);
            return Created($"/album/{temp.Title}",temp);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet ("/titles")]
    public async Task<ActionResult<ICollection<string>>> GetTitles()
    {
        try
        {
            ICollection<string> titles = await _dataAccess.GetAlbumTitlesAsync();
            return Ok(titles);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("/Image")]
    public async Task<ActionResult> AddImageToAlbumAsync(Image image)
    {
        try
        {
            await _dataAccess.AddImageToAlbum(image);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}