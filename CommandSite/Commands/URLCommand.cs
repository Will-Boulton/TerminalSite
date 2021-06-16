using CommandSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandSite.Commands
{
    public class URLCommand : Command
    {
        public URLCommand(string key_websiteName, string URL, Terminal terminal) : base(terminal)
        {
            _key = key_websiteName;
            _helpText = $"Displays {key_websiteName} URL";
            _URL = URL;
        }

        private string _URL;

        private string _key;

        private string _helpText;
        public override string CommandKey => _key;

        public override string HelpString => _helpText;


        public override void Response(TerminalOutput output, params string[] parameters)
        {
            output.AddLine($"\n <a href=\"{_URL} \" target=\"_blank\">My {_key} profile</a> \n\n");
        }
    }
}
