using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.GameCOllection;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository
{
    public class GameCollectionRepository : IGameCollectionRepo
    {

        private readonly ApplicationDBContext _context;
        public GameCollectionRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<GameCollection> CreateAsync(CreateGameCollectionDTO createGameCollectionDTO)
        {
            var gameCollectionData = createGameCollectionDTO.ToGameCollectionFromCreateDTO();

            await _context.GameCollection.AddAsync(gameCollectionData);
            await _context.SaveChangesAsync();

            return gameCollectionData;
        }

        public async Task<GameCollection?> DeleteAsync(long id)
        {
            var gameCollection = await _context.GameCollection.FindAsync(id);
            if (gameCollection == null)
            {
                return null;
            }

            _context.GameCollection.Remove(gameCollection);
            await _context.SaveChangesAsync();

            return gameCollection;
        }

        public async Task<List<GameCollection>> GetAllAsync(GameCollectionQueryObject gameCollectionQueryObject)
        {
            var gameCollections = _context.GameCollection.AsQueryable();
            if (!string.IsNullOrEmpty(gameCollectionQueryObject.SortBy))
            {
                if (gameCollectionQueryObject.SortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    gameCollections = gameCollectionQueryObject.IsDescending ? gameCollections.OrderByDescending(c => c.Name) : gameCollections.OrderBy(c => c.Name);
                }
                if (gameCollectionQueryObject.SortBy.Equals("createdat", StringComparison.OrdinalIgnoreCase))
                {
                    gameCollections = gameCollectionQueryObject.IsDescending ? gameCollections.OrderByDescending(c => c.CreatedAt) : gameCollections.OrderBy(c => c.CreatedAt);
                }
            }

            var skipNumber = (gameCollectionQueryObject.PageNumber - 1) * gameCollectionQueryObject.PageSize;

            return await gameCollections.Skip(skipNumber).Take(gameCollectionQueryObject.PageSize).ToListAsync();
        }

        public async Task<GameCollection?> GetByIdAsync(long id)
        {
            var gameCollection = await _context.GameCollection.FindAsync(id);

            if (gameCollection == null)
            {
                return null;
            }
            return gameCollection;
        }

        public async Task<GameCollection?> UpdateAsync(long id, UpdateGameCollectionDTO updateGameCollectionDTO)
        {
            var gameCollection = await _context.GameCollection.FindAsync(id);

            if (gameCollection == null)
            {
                return null;
            }

            _context.Entry(gameCollection).CurrentValues.SetValues(updateGameCollectionDTO);
            await _context.SaveChangesAsync();

            return gameCollection;
        }
    }
}