using TerminalSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalSite.Commands
{
    public abstract class Command
    {
        public abstract string CommandKey { get; }
        public abstract string HelpString { get; }

        protected virtual List<string> SetAdditionalHelpStrings() => new List<string>();

        public List<string> AdditionalHelpStrings;
        protected Command()
        {
            AdditionalHelpStrings = SetAdditionalHelpStrings();
        }
        public abstract void Execute(Terminal terminal, TerminalOutput output, params string[] parameters);
    }
}
