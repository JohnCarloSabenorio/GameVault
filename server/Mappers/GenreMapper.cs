

using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using server.DTOs.Genre;
using server.Models;

namespace server.Mappers;


public static class GenreMapper
{

    public static GenreDTO ToGenreDTO(this Genre genre)
    {
        return new GenreDTO { Name = genre.Name, Id = genre.Id };
    }
    public static Genre ToGenreFromCreateGenreDTO(this CreateGenreDTO createGenreDTO)
    {
        return new Genre { Name = createGenreDTO.Name };
    }
}