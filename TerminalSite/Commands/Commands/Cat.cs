using TerminalSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TerminalSite.Shared.TerminalResponses;

namespace TerminalSite.Commands
{
    public class CatCommand : Command
    {
        public override string HelpString => "A cute little cat";

        public override string CommandKey => "cat"; 

        public override async void Execute(Terminal terminal, TerminalOutput output, params string[] parameters)
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
                output.AddResponse(new StringLineResponse(line));
                await Task.Delay(25);
            }
        }
    }

}
