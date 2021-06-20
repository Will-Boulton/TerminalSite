using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalSite.Commands
{
    /// <summary>
    /// Store for commands which can be used by the terminal
    /// </summary>
    public static class Commander
    {
        /// <summary>
        /// Initialises commands avaliable, custom URL commands can be added from wwwroot/appsettings.json
        /// </summary>
        /// <param name="websiteConfig"></param>
        public static void Init(IConfiguration websiteConfig)
        {
            AddCommand(new CatCommand());
            AddCommand(new ClearCommand());
            AddCommand(new HelpCommand());
            AddCommand(new LS());
            AddCommand(new CD());
            InitSitecommands(websiteConfig.GetSection("Sites"));

        }

        /// <summary>
        /// Initialises website commands specified in wwwroot/appsettings.json
        /// </summary>
        /// <param name="sites">IConfigurationSection representing the list of sites which are specified in the configuration</param>
        private static void InitSitecommands(IConfigurationSection sites)
        {
            foreach (var siteConfigItem in sites.GetChildren())
            {
                string username = siteConfigItem["Username"];

                string website = siteConfigItem["Website"];

                AddCommand(new URLCommand(website, username, new Uri(siteConfigItem["URL"])));
            }
        }

        /// <summary>
        /// Adds another command to the avaliable commands
        /// </summary>
        /// <param name="c"></param>
        public static void AddCommand(Command c)
        {
            commands[c.CommandKey.ToLower()] = c;
        }

        /// <summary>
        /// Dictionary mapping command keys to commands
        /// </summary>
        public static Dictionary<string, Command> commands = new Dictionary<string, Command>();
    }
}
