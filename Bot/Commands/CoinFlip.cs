using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Threading.Tasks;

namespace Bot.Commands
{
    //command for coinflipping/flipping between two choices
    public class CoinFlip : BaseCommandModule
    {
        [Command("coin")]
        //event handler for calling the "coin" command
        public async Task coin(CommandContext ctx)
        {
            string result = ctx.User.Username + " flips the coin. It was " + flipCoin() + ".";
            await ctx.Channel.SendMessageAsync(result).ConfigureAwait(false);
        }

        [Command("flip")]
        //event handler for calling the "flip" command when there are no preffered choices
        public async Task flip(CommandContext ctx)
        {
            string result = ctx.User.Username + " flips the coin. It was " + flipCoin() + ".";
            await ctx.Channel.SendMessageAsync(result).ConfigureAwait(false);
        }

        [Command("flip")]
        //event handler for calling the "flip" command when the choices are added
        public async Task flip(CommandContext ctx, string first, string second)
        {
            if(flipCoin() == "Heads")
            {
                await ctx.Channel.SendMessageAsync(second).ConfigureAwait(false);
            }
            else
            {
                await ctx.Channel.SendMessageAsync(first).ConfigureAwait(false);
            }            
        }
        //method that generates a random number in range [1,2] and returning heads/tails
        private string flipCoin()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 3);
            if (randomNumber == 1)
            {
                return "Heads";
            }
            return "Tails";
        }
    }
}
