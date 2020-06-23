using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Microsoft.Extensions.Logging;

namespace DiscordBot.Modules.CommandModules
{
    public class YouTubeChannelsModule : ModuleBase
    {
        private readonly ILogger<PingModule> logger;

        public YouTubeChannelsModule(ILogger<PingModule> logger)
        {
            this.logger = logger;
        }

        [Command("ytsetup")]
        public async Task YTSetup()
        {
            logger.LogInformation($"Kanäle werden auf dem Server {base.Context.Guild.Name} erstellt...");
            var _category = (ICategoryChannel)base.Context.Guild.CreateCategoryAsync("YouTube Statistiken");
            var _channel1 = (IVoiceChannel)base.Context.Guild.CreateVoiceChannelAsync("Abonnenten");
            await _channel1.AddPermissionOverwriteAsync("everyone", ChannelPermission.Connect: PermValue.Deny);
            await _channel1.ModifyAsync(ChannelPermissions.Voice.Connect: PermValue.Deny);
        }
    }
}
