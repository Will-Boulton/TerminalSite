using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerminalSite.Models;
using TerminalSite.Shared;

namespace TerminalSite.Commands
{
    public class LS : Command
    {
        public override string CommandKey => "ls";

        public override string HelpString => "List current director contents";

        protected override List<string> SetAdditionalHelpStrings() => new List<string>() { "-v for a fancy verbose output" };


        public override void Execute(Terminal terminal, CommandResponseBlock output, params string[] parameters)
        {
            Directory current = terminal.prompt.CurrentDirectory;

            if(parameters.Contains("-v"))
                ExecuteVerbose(output, current);
            else
                Execute(output, current);


        }

        private void Execute(CommandResponseBlock output, Directory current)
        {
            output.AddResponse(new CommandResponse($"Current Directory: {current.Name}"));

            foreach (var item in current.Children)
            {
                output.AddResponse(new CommandResponse(item.Name));
            }
        }

        private void ExecuteVerbose(CommandResponseBlock output, Directory current)
        {
            string[] resp = current.ToString().Split("\n");

            foreach (string item in resp)
            {
                output.AddResponse(new CommandResponse(item));
            }
        }
    }
}
