using CommandSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandSite.Commands
{
    [CommandHelp("clear", "Clears the terminal", "")]
    public class ClearCommand : Command
    {
        public ClearCommand(Terminal terminal) : base(terminal)
        {
        }

        public override string Response(params string[] parameters)
        {
            this.Terminal.Clear();
            return "";
        }
    }
}
