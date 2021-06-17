using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalSite.Commands
{
    public static class Commander
    {
        public static void Init(IConfigurationSection websiteConfig)
        {
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

                commands[website] = new URLCommand(website, username, new Uri(siteConfigItem["URL"]));
            }
        }


        public static Dictionary<string, Command> commands = new Dictionary<string, Command>();
    }
}
