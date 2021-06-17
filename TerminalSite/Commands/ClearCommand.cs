using TerminalSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalSite.Commands
{
    public class ClearCommand : Command
    {
        public ClearCommand(Terminal terminal) : base(terminal)
        {
        }

        public override string CommandKey => "clear";

        public override string HelpString => "Clears the terminal";

        public override void Response(TerminalOutput output, params string[] parameters)
        {
            this.Terminal.Clear();
        }
    }
}
