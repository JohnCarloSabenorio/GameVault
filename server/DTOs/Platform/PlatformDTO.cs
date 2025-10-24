using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Image;
using server.Models;
namespace server.DTOs.Platform;

public class PlatformDTO
{
    public string? Name { get; set; }
    public long? Generation { get; set; }
    public string? Summary { get; set; }
    public string? Url { get; set; }
    public ImageDTO? Logo { get; set; }

}
