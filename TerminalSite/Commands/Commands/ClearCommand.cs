using TerminalSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalSite.Commands
{
    public class ClearCommand : Command
    {


        public override string CommandKey => "clear";

        public override string HelpString => "Clears the terminal";

        public override void Execute(Terminal terminal, CommandResponseBlock output, params string[] parameters)
        {
            terminal.Clear();
        }
    }
}
