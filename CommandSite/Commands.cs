using CommandSite.Commands;
using CommandSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandSite
{
    public static class Commander
    {

        
    }


    public abstract class Command
    {
        protected Terminal Terminal;
        protected Command(Terminal terminal)
        {
            Terminal = terminal;
        }
        public abstract string Response(params string[] parameters);
    }
}
