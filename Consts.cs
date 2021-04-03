using System.Collections.Generic;

namespace History
{
    public static class Consts
    {
        public static string CONFIG_PATH = "config.json";
        public static int EMBED_COLOUR = 0xFFC800;

        public static Dictionary<string, string> VERSION_INFO = new Dictionary<string, string>()
            {
                {
                    "0.1.0",

                    "Initial version of the bot."
                },
            };
    }
}