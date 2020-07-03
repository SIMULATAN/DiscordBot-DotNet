using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.Domain.Database.Config
{
    public class DBConfiguration
    {
        [JsonProperty(PropertyName = "db_endpoint")]
        public string DbURL { get; set; }
        [JsonProperty(PropertyName = "db_key")]
        public string DbKey { get; set; }
    }
}
