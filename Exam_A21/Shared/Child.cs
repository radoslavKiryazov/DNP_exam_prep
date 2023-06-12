using System.ComponentModel.DataAnnotations;

namespace Shared;

public class Child
{
    public string Name { get; set; }
    [Range(3,6)]
    public int Age { get; set; }
    public string Gender { get; set; }
}