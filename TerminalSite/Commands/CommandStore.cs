using System;
using System.Collections.Generic;

namespace TerminalSite.Commands
{
    /// <summary>
    /// Class for storing previous commands and automatically incrementing between them with a pointer that keeps track of the command being referred to
    /// </summary>
    public class CommandStore
    {
        private List<string> commands;

        private int _pointer;

        private int pointer
        {
            get
            {
                _pointer = Math.Max(Math.Min(_pointer, commands.Count - 1), -1);
                return _pointer;
            }
            set => _pointer = value;
        }

        private string Command(int index) => index >= 0 ? commands[Math.Min(index, commands.Count - 1)] : commands.Count > 0 ? commands[0] : "";

        public CommandStore()
        {
            _pointer = -1;
            commands = new List<string>();
        }

        /// <summary>
        /// Store a command
        /// </summary>
        /// <param name="command"></param>
        public void StoreCommand(string command) { commands.Add(command); pointer = commands.Count - 1; }

        /// <summary>
        /// Retrieve the command which the pointer currently points at or an empty string if there is no command stored
        /// </summary>
        /// <returns></returns>
        public string Command() => Command(pointer);

        /// <summary>
        /// Increment the pointer and then retrieve the command stored against the pointer or an empty string if there are no commands stored
        /// </summary>
        /// <returns></returns>
        public string NextCommand() => Command(++pointer);

        /// <summary>
        /// Decrement the pointer and then retrieve the command stored against the pointer or an empty string if there are no commands stored
        /// </summary>
        /// <returns></returns>
        public string PreviousCommand() => Command(--pointer);
    }
}
