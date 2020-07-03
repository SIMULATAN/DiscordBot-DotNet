using Discord;
using Discord.Commands;
using DiscordBot.Modules.Services;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DiscordBot.Modules
{
    public class UpdateStatusModule : ModuleBase<SocketCommandContext>
    {
        static private int _statusIndex = 0;
        //private AuthorizationService _authorizationService;
        static public int _abort = 1;

        static List<string> _statusList = new List<string>() { "CoderDojoCommunityBot!", "den Code der Coder an" };
        static List<ActivityType> _activityList = new List<ActivityType>() { ActivityType.Playing, ActivityType.Watching };

        //public CustomStatusModule(AuthorizationService authorizationService)
        //{
        //    _authorizationService = authorizationService;
        //}
        [Command("setstatus")]
        public async Task Setstatus(int number, ActivityType activity, [Remainder] string input)
        {
            //if (_authorizationService.IsUserTrusted(base.Context.User.Username + "#" + base.Context.User.DiscriminatorValue))
            //{
                await ReplyAsync($"Der Status {number} wurde auf **{activity} {input}** gesetzt!");
            if (number > _statusList.Count)
            {
                _statusList.Add(input);
                _activityList.Add(activity);
            }
            else
            {
                _statusList[number-1] = input;
                _activityList[number-1] = activity;
            }
            //}
            //else if (!_authorizationService.IsUserTrusted(base.Context.User.Username + "#" + base.Context.User.DiscriminatorValue))
            //{
            //    await ReplyAsync($"Du bist nicht getrustet, {base.Context.User.Mention}");
            //}
            //else
            //{
            //    await ReplyAsync("Ein Fehler ist aufgetreten! Bitte informiere die Admins darüber!");
            //}
        }
        [Command("deletestatus")]
        public async Task Deletestatus(int number)
        {
            //if (useristrusted)
            //{
            _activityList.RemoveAt(number - 1);
            _statusList.RemoveAt(number - 1);
                
            //}
        }
        [Command("activity")]
        public async Task StatusType(string input)
        {
            //if (_authorizationService.IsUserTrusted(base.Context.User.Username + "#" + base.Context.User.DiscriminatorValue) && input == "DnD" || input == "Do not Disturb" || input == "Bitte nicht stören")
            //{
            //    await base.Context.Client.SetStatusAsync(UserStatus.DoNotDisturb);
            //    await ReplyAsync("Der Status wurde auf **Bitte nicht stören** gesetzt!");
            //}
            //else if (_authorizationService.IsUserTrusted(base.Context.User.Username + "#" + base.Context.User.DiscriminatorValue) && input == "Online" || input == "online")
            //{
            //    await base.Context.Client.SetStatusAsync(UserStatus.Online);
            //    await ReplyAsync("Der Status wurde auf **Online** gesetzt!");
            //}
            //else if (_authorizationService.IsUserTrusted(base.Context.User.Username + "#" + base.Context.User.DiscriminatorValue) && input == "AFK" || input == "Afk" || input == "afk")
            //{
            //    await base.Context.Client.SetStatusAsync(UserStatus.AFK);
            //    await ReplyAsync("Der Status wurde auf **Abwesend** gesetzt!");
            //}
            //else if (!_authorizationService.IsUserTrusted(base.Context.User.Username + "#" + base.Context.User.DiscriminatorValue))
            //{
            //    await ReplyAsync($"Du bist nicht getrustet, {base.Context.User.Mention}");
            //}
            //else
            //{
            //    await ReplyAsync("Ein Fehler ist aufgetreten! Bitte informiere die Admins darüber!");
            //}
        }
        [Command("ssu")]
        public async Task StatusUpdater()
        {
            while (true)
            {  
                await base.Context.Client.SetActivityAsync(new Game(_statusList.ElementAtOrDefault(_statusIndex), type: _activityList.ElementAtOrDefault(_statusIndex)));
                _statusIndex = _statusIndex + 1 == _statusList.Count ? 0 : _statusIndex + 1;
                await Task.Delay(TimeSpan.FromSeconds(60/5));
            }
        }
    }
}
