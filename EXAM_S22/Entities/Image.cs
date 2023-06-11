using System.Text.Json.Serialization;

namespace Shared;

public class Image
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string URI { get; set; }
    public string Topic { get; set; }
    
    public Album? Album { get; set; }
    
    public string? Album_title { get; set; }
}