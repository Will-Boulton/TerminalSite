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

        public override string HelpString => "Set the theme for the site, to see all themes run the command 'theme -l'";

        protected override List<string> SetAdditionalHelpStrings() => ThemeController.ThemeNames.Select(t => t.Key).ToList();

        public override void Execute(Terminal terminal, CommandResponseBlock output, params string[] parameters)
        {
            if (parameters.Length != 1 || parameters[0].Equals("-c") || parameters[0].Equals("current"))
            {
                output.AddResponse(new CommandResponse($"{terminal.themeController.SelectedTheme}"));
            }
            else if (ThemeController.ThemeNames.TryGetValue(parameters[0], out Theme theme))
            {
                terminal.themeController.SetTheme(theme);
            }
            else if (parameters[0].Equals("-l") || parameters[0].Equals("list"))
            {
                output.AddResponse(new CommandResponse($"Avaliable Themes:"));
                foreach (var themeName in ThemeController.ThemeNames)
                {
                    output.AddResponse(new CommandResponse($"\t{themeName.Key}"));
                }
            }
            else
            {
                output.AddResponse(new CommandResponse($"Theme \"{parameters[0]}\" is invalid"));

            }
        }
    }
}
