using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalSite.Models
{
    public class PromptContext
    {
        public string User { get; set; }
        public string Separator { get; set; } = "@";
        public Directory CurrentDirectory { get; set; }
        public string PromptString => User + Separator + CurrentDirectory?.Name + " $";
    }
}
