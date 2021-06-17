using TerminalSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TerminalSite.Commands
{
    public class CatCommand : Command
    {
        public override string HelpString => "A cute little cat";

        public override string CommandKey => "cat"; 

        public override async void Response(TerminalOutput output, params string[] parameters)
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
                output.AddLine(line);
                await Task.Delay(25);
            }
        }
    }

}
