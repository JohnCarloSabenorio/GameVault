using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.GamePublisher;
using server.Models;

namespace server.Mappers
{
    public static class GamePublisherMapper
    {
        public static GamePublisherDTO ToGamePublisherDTO(GamePublisher gamePublisher)
        {
            return new GamePublisherDTO { GameId = gamePublisher.GameId, PublisherId = gamePublisher.PublisherId };
        }
    }
}