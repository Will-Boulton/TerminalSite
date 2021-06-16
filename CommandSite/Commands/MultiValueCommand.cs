using CommandSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandSite.Commands
{
    public class MultiValueCommand : Command
    {
        private string[] labels;
        public MultiValueCommand(string key, string helpText, Terminal terminal, Func<string[],string> onRun) :base(terminal)
        {
            this.labels = labels;
            _key = key;
            _helpText = helpText;
            _onRun = onRun; 
        }

        private string _key;

        private string _helpText;

        private Func<string[], string> _onRun;
        public override string CommandKey => _key;

        public override string HelpString => _helpText;

        public override void Response(TerminalOutput output, params string[] parameters) => output.AddLine(_onRun(parameters));
    }
}
