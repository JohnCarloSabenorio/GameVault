

using server.DTOs.VideoGameGenre;
using server.Models;

public static class VideoGameGenreMapper
{
    public static VideoGameGenreDTO ToVideoGameGenreDTO(this VideoGameGenre videoGameGenre)
    {
        return new VideoGameGenreDTO { VideoGameId = videoGameGenre.VideoGameId, GenreId = videoGameGenre.GenreId };
    }
}