using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerminalSite.Controllers;
using TerminalSite.Shared;

namespace TerminalSite.Commands
{
    public class ThemeChooser : Command
    {
        public override string CommandKey => "theme";

        public override string HelpString => "Set the theme for the site";

        public override void Execute(Terminal terminal, CommandResponseBlock output, params string[] parameters)
        {
            if(parameters.Length != 1)
            {
                output.AddResponse(new CommandResponse("Invalid theme set parameters"));
                return;
            }

            if(terminal.themeController.ThemeNames.TryGetValue(parameters[0], out Theme theme))
            {
                terminal.themeController.SetTheme(theme);
            }
            else if(parameters[0].Equals("-c") || parameters[0].Equals("current"))
            {
                output.AddResponse(new CommandResponse($"The current theme is: {terminal.themeController.SelectedTheme}"));
            }
            else
            {
                output.AddResponse(new CommandResponse($"Theme \"{parameters[0]} is invalid"));

            }
        }
    }
}
