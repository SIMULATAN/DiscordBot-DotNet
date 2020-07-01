using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Microsoft.Extensions.Logging;

namespace DiscordBot.Modules.CommandModules
{
    public class ModerationModule : ModuleBase
    {
        private readonly ILogger<PingModule> logger;

        public ModerationModule(ILogger<PingModule> logger)
        {
            this.logger = logger;
        }

        [Command("ban")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task Ban()
        {
            var user = base.Context.Message.MentionedUserIds.First();
            logger.LogInformation($"Der Benutzer {base.Context.User.Username} versucht den User {Context.Message.MentionedUserIds.First()} zu bannen.");
            await base.Context.Guild.AddBanAsync(user);
            IUser user1 = (IUser)base.Context.Guild.GetUserAsync(user);
            user1.SendMessageAsync($"Du wurdest vom Server {base.Context.Guild.Name} von {base.Context.User.Username} gebannt!");
            await ReplyAsync("Der User wurde gebannt.");
        }
        [Command("unban")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task Unban(string username)
        {
            var userID = Context.User.Discriminator;
            var user = Context.Client.GetUserAsync(userID);
            logger.LogInformation($"Der Benutzer {base.Context.User.Username} versucht den User {Context.Message.MentionedUserIds.First()} zu entbannen");
            await base.Context.Guild.RemoveBanAsync(user);
        }
    }
}
