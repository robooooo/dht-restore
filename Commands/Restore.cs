using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace History
{
    public partial class Commands
    {
        [Command("restore")]
        [Description("automatically restores a server from a given history tracker file")]
        public async Task Restore(CommandContext ctx)
        {

            // Grab the DHT file and download it
            var Filename = $"{ctx.Message.Id.ToString()}.json";
            var HistoryFile = ctx.Message.Attachments
                .Where(a => a.FileName.Equals("dht.txt")).First();
            var HistoryUri = new Uri(HistoryFile.Url);
            await Client.DownloadFileTaskAsync(HistoryUri, Filename);

            // Open and parse it
            var RawHistory = File.ReadAllText(Filename);
            File.Delete(Filename);
            await ctx.Message.DeleteAsync();
            var History = JsonSerializer.Deserialize<History>(RawHistory);

            // Create some channels
            var Category = await ctx.Guild.CreateChannelCategoryAsync("Archives");
            foreach (var pair in History.Data)
            {
                var ChannelData = History.Meta.Channels[pair.Key];
                var Channel = await ctx.Guild.CreateChannelAsync(ChannelData.Name, ChannelType.Text, Category);
                var Hook = await Channel.CreateWebhookAsync("Histo-hook");

                // Ruffle through them
                foreach (var message in pair.Value)
                {
                    await SendAs(Hook, History.Meta, message.Value);
                }

                await Hook.DeleteAsync();
            }
        }

        public async Task SendAs(DiscordWebhook hook, Metadata meta, Message message)
        {
            var UserId = meta.UserIndex[message.UserIndex];
            var User = meta.Users[UserId];

            var Builder = new DiscordWebhookBuilder()
            {
                AvatarUrl = User.Avatar ?? Optional.FromNoValue<string>(),
                // Avoid empty messages with this message that looks empty, but isn't
                Content = String.IsNullOrWhiteSpace(message.Content) ? "** **" : message.Content,
                Username = User.Name ?? "Unknown User",
            };

            if (message.Attatchments != null)
            {
                Builder.AddEmbeds(message.Attatchments
                    .Where(a => a.Url != null)
                    .Select(a =>
                    {
                        return new DiscordEmbedBuilder()
                        {
                            ImageUrl = a.Url,
                        }
                        .Build();
                    })
                );
            }

            await hook.ExecuteAsync(Builder);
        }
    }
}