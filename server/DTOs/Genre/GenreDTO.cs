using System.ComponentModel.DataAnnotations;

namespace server.DTOs.Genre;


public class GenreDTO
{

    public long Id { get; set; }
    public string? Name { get; set; }
}