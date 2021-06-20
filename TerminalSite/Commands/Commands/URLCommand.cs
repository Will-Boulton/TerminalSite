using TerminalSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalSite.Commands
{
    /// <summary>
    /// A command which returns an annotated URL
    /// </summary>
    public class URLCommand : Command
    {
        public URLCommand(string key_websiteName, string Username, Uri URL)
        {
            _key = key_websiteName;
            _helpText = $"Displays {key_websiteName} URL";

            url = new AnnotatedURL($"\n\t{Username} on {_key}\n", URL);
        }

        AnnotatedURL url;

        private string _key;

        private string _helpText;
        public override string CommandKey => _key;

        public override string HelpString => _helpText;


        public override void Execute(Terminal terminal, CommandResponseBlock output, params string[] parameters)
        {

            output.AddResponse(new CommandResponse(url));
        }
    }
}
