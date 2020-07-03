using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.Domain.Database.Service
{
    public interface IDatabaseService
    {
        public CosmosClient Client { get; }
    }
}
