using System.Collections.Generic;

namespace TravelPlanner;

public class TravelData
{
    public string UserName { get; set; }
    public string Country { get; set; }
    public List<string> Attractions { get; set; } = new();
    public string Transport { get; set; }
    public List<string> Cities { get; set; } = new();
}
