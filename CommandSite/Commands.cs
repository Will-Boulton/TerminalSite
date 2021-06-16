using CommandSite.Commands;
using CommandSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandSite
{
    public abstract class Command
    {
        public abstract string CommandKey { get; }
        public abstract string HelpString { get; }

        protected virtual List<string> SetAdditionalHelpStrings() => new List<string>();

        public List<string> AdditionalHelpStrings;

        protected Terminal Terminal;
        protected Command(Terminal terminal)
        {
            Terminal = terminal;
            AdditionalHelpStrings = SetAdditionalHelpStrings();
        }
        public abstract  void Response(TerminalOutput output, params string[] parameters);
    }
}
