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
        [RequireOwner]
        public async Task YTSetup()
        {
            var role = base.Context.Guild.GetRole(base.Context.Guild.Id);
            logger.LogInformation($"Kanäle werden auf dem Server {base.Context.Guild.Name} erstellt...");
            ulong _categoryID = ((await base.Context.Guild.CreateCategoryAsync("YouTube Statistiken")).Id);
            var _channel3 = (await base.Context.Guild.CreateVoiceChannelAsync("Name", prop => prop.CategoryId = _categoryID));
            await _channel3.AddPermissionOverwriteAsync(role, OverwritePermissions.DenyAll(_channel3).Modify(viewChannel: PermValue.Allow));
            var _channel1 = (await base.Context.Guild.CreateVoiceChannelAsync("Abonnenten", prop => prop.CategoryId = _categoryID));
            await _channel1.AddPermissionOverwriteAsync(role, OverwritePermissions.DenyAll(_channel1).Modify(viewChannel: PermValue.Allow));
            var _channel2 = (await base.Context.Guild.CreateVoiceChannelAsync("Views", prop => prop.CategoryId = _categoryID));
            await _channel2.AddPermissionOverwriteAsync(role, OverwritePermissions.DenyAll(_channel2).Modify(viewChannel: PermValue.Allow));
            await ReplyAsync("Erfolgreich YouTube Statistiken-Kanäle erstellt!");
        }
    }
}
