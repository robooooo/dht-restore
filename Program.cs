using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Logging;

namespace History
{
    public class Program
    {
        static DiscordClient Discord;
        static CommandsNextExtension Commands;

        public static void Main(string[] args)
        {
            // Initialise with bot token
            var RawConfigs = File.ReadAllText(Consts.CONFIG_PATH);
            var Configs = JsonSerializer.Deserialize<Configuration>(RawConfigs);
            Discord = new DiscordClient(new DiscordConfiguration
            {
                Token = Configs.Token,
                TokenType = TokenType.Bot,
                MinimumLogLevel = LogLevel.Debug,
                // Caused issues with crashing & stalling 
                // However, we'll try it for now
                AutoReconnect = true,
            });

            Commands = Discord.UseCommandsNext(new CommandsNextConfiguration
            {
                CaseSensitive = false,
                EnableDefaultHelp = true,
                EnableDms = false,
                EnableMentionPrefix = true,
                StringPrefixes = new string[] { "dht!" }
            });

            Discord.Ready += async (_, e) =>
            {
                string LatestVersion = Consts.VERSION_INFO.First().Key;
                await Discord.UpdateStatusAsync(new DiscordActivity($"Ver. {LatestVersion}", ActivityType.Playing));
            };

            Commands.CommandErrored += Events.CommandErrored;

            Commands.RegisterCommands<Commands>();
            Commands.SetHelpFormatter<HelpFormatter>();
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            await Discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}