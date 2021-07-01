using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerminalSite.Models;

namespace TerminalSite.Controllers
{
    public class FileSystem
    {
        public Directory root;

        public FileSystem(IConfigurationSection fileSystem)
        {
            root = ParseDirectory(fileSystem);
        }

        private Directory ParseDirectory(IConfigurationSection section)
        {
            string DirectoryName = section["name"];

            IConfigurationSection filessection = section.GetSection("files");
            

            IEnumerable<IFileSystemObject> files = filessection.Exists() ? filessection.GetChildren().Select(file =>  ParseFile(file)) : new List<IFileSystemObject>();

            IConfigurationSection directoriessection = section.GetSection("child-dirs");

            IEnumerable<IFileSystemObject> directories = directoriessection.Exists() ?  directoriessection.GetChildren().Select(file => ParseDirectory(file)) : new List<IFileSystemObject>();

            return new Directory(DirectoryName).SetChildren( directories.Union(files) );
        }

        private File ParseFile(IConfigurationSection section)
        {
            string filename = section["name"];
            string extension = section["extension"];
            string contents = string.Join('\n',section.GetSection("contents").GetChildren().Select(x => x.Value));

            return new File(filename, extension) { contents = contents};
        }
    }
}
