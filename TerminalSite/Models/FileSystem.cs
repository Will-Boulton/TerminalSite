using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalSite.Models
{
    public static class FileSystem
    {
        public static Directory root;

        public static void Init()
        {
            root = new Directory("root");
            Directory sub1 = new Directory("SecretFiles");
            sub1.AddChild(new File("Passwords","txt"));
            root.AddChild(sub1);
            root.AddChild(new File("Nice","txt"));
        }
    }
}
