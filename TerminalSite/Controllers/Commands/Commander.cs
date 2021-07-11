using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerminalSite.Commands;

namespace TerminalSite.Controllers
{
    /// <summary>
    /// Store for commands which can be used by the terminal
    /// </summary>
    public class Commander
    {
        /// <summary>
        /// Initialises commands avaliable, custom URL commands can be added from wwwroot/appsettings.json
        /// </summary>
        /// <param name="websiteConfig"></param>
        public Commander(IConfiguration websiteConfig)
        {
            AddCommand(new CatCommand());
            AddCommand(new ClearCommand());
            AddCommand(new HelpCommand());
            AddCommand(new LS());
            AddCommand(new CD());
            AddCommand(new ThemeChooser());
            InitSitecommands(websiteConfig.GetSection("Sites"));

        }

        /// <summary>
        /// Initialises website commands specified in wwwroot/appsettings.json
        /// </summary>
        /// <param name="sites">IConfigurationSection representing the list of sites which are specified in the configuration</param>
        private void InitSitecommands(IConfigurationSection sites)
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
        public void AddCommand(Command c)
        {
            commands[c.CommandKey.ToLower()] = c;
        }

        /// <summary>
        /// Dictionary mapping command keys to commands
        /// </summary>
        public static Dictionary<string, Command> commands = new Dictionary<string, Command>();

        public static string AutoComplete(string commandString)
        {
            if(commandString == null)
                return null;

            string[] cmdAndArgs = commandString.Split(null);

            //We have no command so tab is useless 
            if(cmdAndArgs.Length == 0)
                return "";

            //We find a direct match for the provided command name
            if(commands.TryGetValue(cmdAndArgs[0], out Command matchedCommand))
            {
                //We don't have any params so just do nothing
                if(cmdAndArgs.Length == 1)
                    return matchedCommand.CommandKey;

                //Otherwise we hand over autocomplete to the command
                return matchedCommand.AutoComplete(cmdAndArgs.Skip(1));
            }
            
            //No matched command but a command name is specified
            //Now we look for the closest match to the given command name
            return StringDistanceUtils.ClosestMatch(cmdAndArgs[0], commands.Keys);
            
        }
    }
}
