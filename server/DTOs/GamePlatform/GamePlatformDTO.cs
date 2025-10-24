using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.Image;
using server.Models;
namespace server.DTOs.Platform;

public class GamePlatformDTO
{
    public string? Name { get; set; }
    public long? Generation { get; set; }
    public string? Summary { get; set; }
    public string? Url { get; set; }
    public string? LogoName { get; set; }

}
