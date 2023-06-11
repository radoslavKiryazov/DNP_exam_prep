using System.Text.Json.Serialization;

namespace Shared;

public class Album
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CreatedBy{ get; set; }

    
    [JsonIgnore]
    public ICollection<Image>? Images { get; set; }
}