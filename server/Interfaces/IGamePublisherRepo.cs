using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Interfaces
{
    public interface IGamePublisherRepo
    {
        Task<List<Publisher>> GetGamePublishers(long gameId);
        Task<GamePublisher> CreateAsync(long gameId, long publisherId);
        Task<GamePublisher?> DeleteAsync(long gameId, long publisherId);
        Task<bool> GamePublisherExists(long gameId, long publisherId);
    }
}