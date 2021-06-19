using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalSite.Models
{
    public class TerminalInputModel
    { 
    
        private static int key_ = 0;
        public int Key = key_++;
        public bool Disabled { get; set; } = false;
        public string Placeholder { get; set; } = "";
        public string Value { get; set; }

        public PromptContext Prompt { get; set; } = new PromptContext();
    }
}
