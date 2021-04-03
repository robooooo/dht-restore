using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.EventArgs;

namespace History
{
    public static class Events
    {
        public static async Task CommandErrored(CommandsNextExtension ext, CommandErrorEventArgs e)
        {
            DiscordEmbedBuilder Builder = new DiscordEmbedBuilder
            {
                Color = new DiscordColor(0xB00020),
                Title = "❌ Error!",
                Description = $"In `{e.Command.Name}`",
            };

            Exception ex = e.Exception;
            while (ex != null)
            {
                if (e.Exception.Message == "One or more pre-execution checks failed.")
                    Builder.AddField("Reason", "You lack the required permissions to run this command in this channel.");
                else
                    Builder.AddField("Reason", e.Exception.Message);
                ex = ex.InnerException;
            }
            // Builder.AddField("Stack Trace:", $"```{e.Exception.StackTrace}```");
            // Builder = Builder.WithFooter(text: "If you think this shouldn't be happening, consider submitting a bug report in our support server.");
            await e.Context.Channel.SendMessageAsync(embed: Builder);
        }
    }
}
