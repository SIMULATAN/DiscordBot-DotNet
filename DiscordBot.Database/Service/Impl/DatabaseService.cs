using DiscordBot.Domain.Database.Config;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.Domain.Database.Service.Impl
{
    public class DatabaseService : IDatabaseService
    {
        private IOptions<DBConfiguration> _configuration;
        private CosmosClient _client;
        public DatabaseService(IOptions<DBConfiguration> configuration)
        {
            _configuration = configuration;
        }
        public CosmosClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new CosmosClient(_configuration.Value.DbURL, _configuration.Value.DbKey);
                }

                return _client;
            }
        }
    }
}
