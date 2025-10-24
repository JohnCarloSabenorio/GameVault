

using server.DTOs.GameGenre;
using server.Models;

public static class GameGenreMapper
{
    public static GameGenreDTO ToGameGenreDTO(this GameGenre gameGenre)
    {
        return new GameGenreDTO { GameId = gameGenre.GameId, GenreId = gameGenre.GenreId };
    }
}