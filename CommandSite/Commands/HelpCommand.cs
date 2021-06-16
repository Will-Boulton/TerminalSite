using CommandSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandSite.Commands
{
    public class HelpCommand : Command
    {
        public HelpCommand(Terminal terminal) : base(terminal) 
        {
        }

        public override string CommandKey => "help";

        public override string HelpString => "Use flag -v to show additional help info";

        protected override List<string>  SetAdditionalHelpStrings() => new List<string>() { "run help <command> to get the help for a specific command", "-v for verbose help" };
        private static int MIN_WHITESPACE = 4;
        private static int DESIRED_WHITESPACE = 10;          
        public override void Response(TerminalOutput output, params string[] parameters)
        {
            bool verbose = parameters.Contains("-v");

            StringBuilder sb = new StringBuilder();
            foreach (var item in parameters)
            {
                if (Terminal.commandOptions.TryGetValue(item, out Command command))
                {
                    CommandString(command, DESIRED_WHITESPACE,sb, verbose);
                    output.AddLine(sb.ToString());
                    return;
                }
            }
            

            int whitespace = Math.Max(Terminal.commands.Select(x => x.CommandKey.Length).Max() + MIN_WHITESPACE, DESIRED_WHITESPACE);


            foreach (Command cmd in Terminal.commands)
            {
                CommandString(cmd,whitespace,sb,verbose);
            }

            output.AddLine(sb.ToString());
        }

        private void CommandString(Command cmd, int whitespace, StringBuilder sb, bool showAdditionalHelp = false)
        {
            string key = cmd.CommandKey;
            int thisws = whitespace - key.Length;
            sb.Append(key).Append(new string(' ', thisws)).AppendLine();
            sb.Append(new string(' ', whitespace)).Append(cmd.HelpString).AppendLine();

            if(showAdditionalHelp)
                AdditionalCommandString(cmd,whitespace,sb);

            sb.AppendLine();
        }



        private void AdditionalCommandString(Command cmd, int whitespace, StringBuilder sb)
        {
            foreach (var item in cmd.AdditionalHelpStrings)
            {
                sb.Append(new string(' ', whitespace)).Append(item).AppendLine().AppendLine();
            }
        }
    }

    public class CommandHelpAttribute : Attribute
    {
        public string PrimaryCommand;
        public string Description;

        public string HelpText;
        public CommandHelpAttribute(string primaryCommand, string description, string helpText)
        {
            PrimaryCommand = primaryCommand;
            Description = description;
            HelpText = helpText;
        }
    }
}
