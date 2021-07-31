using TerminalSite.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalSite.Commands
{
    /// <summary>
    /// Base class for commands which are executable in the <see cref="Terminal"/>
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Key string used to execute a command
        /// </summary>
        public abstract string CommandKey { get; }

        /// <summary>
        /// Primary help string shown when a <see cref="HelpCommand"/> is executed
        /// </summary>
        public abstract string HelpString { get; }

        /// <summary>
        /// List of additional help strings shown when  a <see cref="HelpCommand"/> is executed with the -v flag
        /// </summary>
        /// <returns></returns>
        protected virtual List<string> SetAdditionalHelpStrings() => new List<string>();

        public List<string> AdditionalHelpStrings;
        protected Command()
        {
            AdditionalHelpStrings = SetAdditionalHelpStrings();
        }

        /// <summary>
        /// Abstract method for executing a command
        /// </summary>
        /// <param name="terminal">Terminal reference allow controlling state from</param>
        /// <param name="output">Dedicated block to add responses to</param>
        /// <param name="parameters">Params used to modify command behaviour</param>
        public abstract void Execute(Terminal terminal, CommandResponseBlock output, params string[] parameters);

        public virtual string AutoComplete(IEnumerable<string> args) => CommandKey.ToLower() + " "+ String.Join(' ', args);
    }
}
