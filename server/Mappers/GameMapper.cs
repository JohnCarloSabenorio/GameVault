using Microsoft.AspNetCore.StaticAssets;
using server.DTOs.Game;
using server.Models;

namespace server.Mappers;


public static class GameMapper
{
    public static GameDTO ToGameDTO(this Game game)
    {
        return new GameDTO
        {
            Id = game.Id,
            Name = game.Name,
            Storyline = game.Storyline,
            Summary = game.Summary,
            Rating = game.Rating,
            RatingCount = game.RatingCount,
            TotalFavorited = game.TotalFavorited,
            TotalPlayers = game.TotalPlayers,
            TotalUnitSold = game.TotalUnitSold,
            Price = game.Price,
            FranchiseId = game.FranchiseId,
            ImageId = game.ImageId,
            StatusId = game.StatusId,
            ReleaseDate = game.ReleaseDate,
            CreatedAt = game.CreatedAt,
            UpdatedAt = game.UpdatedAt,
            Reviews = game.Reviews.Select(r => r.ToReviewDTO()).ToList()
        };
    }

    public static Game ToGameFromCreateDTO(this CreateGameDTO createGameDTO)
    {
        return new Game
        {
            Name = createGameDTO.Name,
            Storyline = createGameDTO.Storyline,
            Summary = createGameDTO.Summary,
            Rating = createGameDTO.Rating,
            RatingCount = createGameDTO.RatingCount,
            TotalFavorited = createGameDTO.TotalFavorited,
            TotalPlayers = createGameDTO.TotalPlayers,
            TotalUnitSold = createGameDTO.TotalUnitSold,
            Price = createGameDTO.Price,
            FranchiseId = createGameDTO.FranchiseId,
            StatusId = createGameDTO.StatusId,
            ImageId = createGameDTO.ImageId,
            ReleaseDate = createGameDTO.ReleaseDate,
        };
    }
}