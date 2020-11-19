using Bot.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    //basic bot class
    class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            //reading the config file
            var json = string.Empty; //faster string initalization
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            //converting the file read in a ConfigJson type file
            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            //settubg up the configuration
            var config = new DiscordConfiguration {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };

            Client = new DiscordClient(config);
            Client.Ready += OnClientReady;
            
            var commandsConfig = new CommandsNextConfiguration{
                StringPrefixes = new string[] {configJson.Prefix },
                EnableMentionPrefix = true,
                EnableDms = false
            };

            Commands = Client.UseCommandsNext(commandsConfig);
            RegisterCommands(); //checking for commands
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task OnClientReady(DiscordClient sender, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
        //method that checks if one of the commands have been registered
        private void RegisterCommands()
        {
            Commands.RegisterCommands<Roll>();
            Commands.RegisterCommands<CoinFlip>();
            Commands.RegisterCommands<Avatar>();
        }
    }
}
