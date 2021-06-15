using CommandSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandSite.Commands
{
    [CommandHelp("cat", "A cute little cat", "")]
    public class CatCommand : Command
    {
        public CatCommand(Terminal terminal) : base(terminal) { }
        public override string Response(params string[] parameters)
        {
            return
@"
                      ／|、        
        meow      ﾞ （ﾟ､ ｡ ７     
                     |、ﾞ ~ヽ      
                     じしf_, )ノ  ";
        }
    }

}
