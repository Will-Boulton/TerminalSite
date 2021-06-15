using CommandSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandSite.Commands
{
    public class MultiValueCommand : Command
    {
        private string[] labels;
        public MultiValueCommand(string description, string helpText, Terminal terminal, params string[] labels) :base(terminal)
        {
            this.labels = labels;
        }

        public override string Response(params string[] parameters)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < labels.Length; i++)
            {
                sb.Append(labels[i]);

                if((i+1) % labels.Length != 0)
                    sb.Append(" -- ");
            }
            return sb.ToString();
        }
    }
}
