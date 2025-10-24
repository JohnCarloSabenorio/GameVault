using Microsoft.AspNetCore.StaticAssets;
using server.DTOs.VideoGame;
using server.Models;

namespace server.Mappers;


public static class VideoGameMapper
{
    public static GameDTO ToVideoGameDTO(this Game videoGame)
    {
        return new GameDTO
        {
            Id = videoGame.Id,
            Name = videoGame.Name,
            Storyline = videoGame.Storyline,
            Summary = videoGame.Summary,
            Rating = videoGame.Rating,
            RatingCount = videoGame.RatingCount,
            TotalFavorited = videoGame.TotalFavorited,
            TotalPlayers = videoGame.TotalPlayers,
            TotalUnitSold = videoGame.TotalUnitSold,
            Price = videoGame.Price,
            FranchiseId = videoGame.FranchiseId,
            ImageId = videoGame.ImageId,
            StatusId = videoGame.StatusId,
            ReleaseDate = videoGame.ReleaseDate,
            CreatedAt = videoGame.CreatedAt,
            UpdatedAt = videoGame.UpdatedAt,
            Reviews = videoGame.Reviews.Select(r => r.ToReviewDTO()).ToList()
        };
    }

    public static Game toVideoGameFromCreateDTO(this CreateGameDTO createVideoGameDTO)
    {
        return new Game
        {
            Name = createVideoGameDTO.Name,
            Storyline = createVideoGameDTO.Storyline,
            Summary = createVideoGameDTO.Summary,
            Rating = createVideoGameDTO.Rating,
            RatingCount = createVideoGameDTO.RatingCount,
            TotalFavorited = createVideoGameDTO.TotalFavorited,
            TotalPlayers = createVideoGameDTO.TotalPlayers,
            TotalUnitSold = createVideoGameDTO.TotalUnitSold,
            Price = createVideoGameDTO.Price,
            FranchiseId = createVideoGameDTO.FranchiseId,
            StatusId = createVideoGameDTO.StatusId,
            ImageId = createVideoGameDTO.ImageId,
            ReleaseDate = createVideoGameDTO.ReleaseDate,
        };
    }
}