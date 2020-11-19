using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Threading.Tasks;

namespace Bot.Commands
{
    public class Roll : BaseCommandModule
    {
        //public async Task<int> to return
        [Command("roll")]
        //event handler for when the range is specified
        public async Task roll(CommandContext ctx, string value)
        {
            await ctx.Channel.SendMessageAsync(GenerateResult(Int32.Parse(value), ctx.User.Username)).ConfigureAwait(false);
        }

        [Command("roll")]
        //event handler for when the range is unspecified
        public async Task roll(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync(GenerateResult(100,ctx.User.Username)).ConfigureAwait(false);
        }
        //method that generates a response for the rolling command
        //generates a number between [1,range]
        private string GenerateResult (int range, string userName)
        {
            string result = userName + " rolls ";
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, range + 1);
            result += randomNumber.ToString() + " (1-" + range.ToString() + ").";
            return result;
        }

    }
}
