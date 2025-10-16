using Microsoft.AspNetCore.StaticAssets;
using server.DTOs.VideoGame;
using server.Models;

namespace server.Mappers;


public static class VideoGameMapper
{
    public static VideoGameDTO ToVideoGameDTO(this VideoGame videoGame)
    {
        return new VideoGameDTO { Title = videoGame.Title, Description = videoGame.Description, CreatedOn = videoGame.CreatedOn, Reviews = videoGame.Reviews.Select(r => r.ToReviewDTO()).ToList() };
    }

    public static VideoGame toVideoGameFromCreateDTO(this CreateVideoGameDTO createVideoGameDTO)
    {
        return new VideoGame { Title = createVideoGameDTO.Title, Description = createVideoGameDTO.Description, CreatedOn = createVideoGameDTO.CreatedOn };
    }
}