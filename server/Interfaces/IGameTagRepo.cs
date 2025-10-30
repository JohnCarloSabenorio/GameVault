using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Interfaces
{
    public interface IGameTagRepo
    {
        Task<List<Tag>> GetGameTags(long gameId);
        Task<GameTag> CreateAsync(long gameId, long tagId);
        Task<GameTag?> DeleteAsync(long gameId, long tagId);
        Task<bool> GameTagExists(long gameId, long tagId);

    }
}