using TerminalSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TerminalSite.Models;

namespace TerminalSite.Commands
{
    /// <summary>
    /// Cat command, which immitates a simplified version if linux's 'cat'
    /// </summary>
    public class CatCommand : Command
    {
        public override string HelpString => "Read a files contents";

        public override string CommandKey => "cat";

        public override void Execute(Terminal terminal, CommandResponseBlock output, params string[] parameters)
        {
            if(parameters.Length == 0)
                PrintCat(output);
            else
                PrintFile(terminal, output, parameters);

        }

        private void PrintFile(Terminal terminal, CommandResponseBlock output, params string[] parameters)
        {
            string file = parameters[0];

            Directory current = terminal.prompt.CurrentDirectory;

            File newDir = (File)current.Children.FirstOrDefault(x => (x.Name == file || x.Name.Split('.')[0] == file) && x is File);

            if(newDir != null)
            {
                foreach (string line in newDir.contents.Split("\n"))
                {
                    output.AddResponse(new CommandResponse(line));
                }
            }
            else
            {
                output.AddResponse(new CommandResponse($"File '{file}' not found!"));
            }
        }

        private async void PrintCat(CommandResponseBlock output)
        {
            var cat =
@"
                      ／|、        
        meow      ﾞ （ﾟ､ ｡ ７     
                     |、ﾞ ~ヽ      
                     じしf_, )ノ  
                                    ";
            foreach (var line in cat.Split(Environment.NewLine))
            {
                output.AddResponse(new CommandResponse(line));
                await Task.Delay(25);
            }
        }
    }

}
