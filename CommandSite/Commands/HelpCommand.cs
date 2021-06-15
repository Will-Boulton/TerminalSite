using CommandSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandSite.Commands
{
    [CommandHelp("help","Display helpful information about each command","")]
    public class HelpCommand : Command
    {
        
        public HelpCommand(Terminal terminal) : base(terminal) { }
        public override string Response(params string[] parameters)
        {
            var CommandTypes = Assembly.GetAssembly(typeof(Command)).GetTypes()
                .Where(myType => 
                myType.IsClass && 
                !myType.IsAbstract && 
                myType.IsSubclassOf(typeof(Command))).Select( x => x.GetCustomAttribute(typeof(CommandHelpAttribute))).ToArray();



            StringBuilder sb = new StringBuilder();

            foreach (CommandHelpAttribute commandType in CommandTypes.Where(t => t != null))
            {
                sb.Append(commandType.PrimaryCommand).Append("    ").Append(commandType.Description).AppendLine();
                sb.Append("         ").Append(commandType.HelpText).AppendLine();
            }

            return sb.ToString();
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
