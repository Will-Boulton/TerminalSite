using TerminalSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerminalSite.Shared.TerminalResponses;

namespace TerminalSite.Commands
{
    public class URLCommand : Command
    {
        public URLCommand(string key_websiteName, string Username, Uri URL)
        {
            _key = key_websiteName;
            _helpText = $"Displays {key_websiteName} URL";
            _URL = URL;
            _Username = Username;
        }

        private Uri _URL;

        private string _Username;

        private string _key;

        private string _helpText;
        public override string CommandKey => _key;

        public override string HelpString => _helpText;


        public override void Execute(Terminal terminal, TerminalOutput output, params string[] parameters)
        {
            output.AddResponse(new StringLineResponse( $"\n <a href=\"{_URL} \" target=\"_blank\">{_Username} on {_key}.</a> \n\n"));
        }
    }
}
