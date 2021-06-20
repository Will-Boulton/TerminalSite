using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerminalSite.Models;
using TerminalSite.Shared;

namespace TerminalSite.Commands
{
    /// <summary>
    /// Command to change the current directory of the terminal
    /// </summary>
    public class CD : Command
    {
        public override string CommandKey => "cd";

        public override string HelpString => "Change Directory";
        protected override List<string> SetAdditionalHelpStrings() => new List<string>() 
        {
            "Use 'cd' to go up a directory",
            "Use 'cd <dir> to go into a specific sub directory"
        };

        public override void Execute(Terminal terminal, CommandResponseBlock output, params string[] parameters)
        {
            Directory current = terminal.prompt.CurrentDirectory;
            
            if(parameters.Length == 0)
                UpDir(terminal, current);
            else if(parameters.Length == 1)
            {
                downDir(terminal, output, current, parameters[0]);
            }
            else
            {
                output.AddResponse(new CommandResponse($"Invalid parameters"));
            }
        }

        private void UpDir(Terminal terminal, Directory current)
        {
            if(current.Parent != null)
            {
                terminal.prompt.CurrentDirectory = current.Parent;
            }
        }

        private void downDir(Terminal terminal, CommandResponseBlock output, Directory current, string subdir)
        {
            Directory newDir = (Directory) current.Children.FirstOrDefault(x => x.Name == subdir && x is Directory);

            if(newDir != null)
                terminal.prompt.CurrentDirectory = newDir;
            else
            {
                output.AddResponse(new CommandResponse($"Directory '{subdir}' does not exist"));
            }
        }
    }
}
