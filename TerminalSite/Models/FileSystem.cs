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
            sub1.AddChild(new File("Passwords","txt"){ contents = "Nice try :p"});
            root.AddChild(sub1);
            root.AddChild(new File("About","txt") 
                { 
                    contents = 
@"Hi!

I am Will Boulton, a full-stack Software Engineer working in London.

This site is developed in .Net Blazor using Web Assembly, 
Kinda cool!
"
                });
        }
    }
}
