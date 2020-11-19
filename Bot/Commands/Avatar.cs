using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace Bot.Commands
{
    //command that retrieves user's avatar and posts it
    public class Avatar : BaseCommandModule
    {
        [Command("avatar")]
        //command handler if user asks for his avatar
        public async Task avatar(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync(ctx.User.AvatarUrl).ConfigureAwait(false);
        }

        [Command("avatar")]
        //command handler if user asks for another user's avatar
        public async Task avatar(CommandContext ctx, DiscordUser cont)
        {
            await ctx.Channel.SendMessageAsync(cont.AvatarUrl).ConfigureAwait(false);
        }
    }
}
