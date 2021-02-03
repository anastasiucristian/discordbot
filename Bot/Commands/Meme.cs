using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;
using System.Net;
using System;
using System.Web;
using HtmlAgilityPack;
using System.Threading;

namespace Bot.Commands
{
    class Meme : BaseCommandModule
    {
        private string uri = "https://www.reddit.com/random";

        [Command("meme")]        
        public async Task meme(CommandContext ctx)
        {
            while (uri == "https://www.reddit.com/random")
            {
                generateRandomUrl();
            }


            // Download the HTML
            var client = new WebClient();
            string html = client.DownloadString(uri);
            //Console.WriteLine(client.Site.Name);

            // Now feed it to HTML Agility Pack:
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            string finalUri = string.Empty; //image uri
            foreach (HtmlNode linke in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute href = linke.Attributes["href"];
                if (href.Value.ToString().Contains("redd.it"))
                {
                    finalUri = href.Value.ToString();
                    uri = "https://www.reddit.com/random";
                }
            }

            //post image link
            await ctx.Channel.SendMessageAsync(finalUri).ConfigureAwait(false);
        }

        private void generateRandomUrl()
        {
            if(uri == "https://www.reddit.com/random")
            {
                var request = WebRequest.Create(uri);
                var response = request.GetResponse();
                uri = response.ResponseUri.ToString();
                Console.WriteLine("new url");
                if (uri.Contains("meme") == false) //if uri is not a meme reset to random post
                {
                    uri = "https://www.reddit.com/random"; //gets a random reddit post
                }
                else
                {
                    Console.WriteLine("Meme found");
                }
                
            }
        }
    }
}
