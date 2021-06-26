using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerminalSite.Models
{
    public interface IFileSystemObject
    {
        string Name { get; set; }
        Directory Parent { get; set; }

        string ls(int depth);
    }

    public class Directory : IFileSystemObject
    {
        public string Name { get; set; }
        public List<IFileSystemObject> Children { get; set; } = new List<IFileSystemObject>();
        public Directory Parent { get; set; }

        public Directory(string name)
        {
            Name = name;
        }

        public Directory SetChildren(IEnumerable<IFileSystemObject> children)
        {
            foreach (var item in children)
            {
                AddChild(item);
            }
            return this;
        }

        public void AddChild(IFileSystemObject d)
        {
            Children.Add(d);
            d.Parent = this;
        }

        private string Indent(int depth) => new string(' ', depth * 2);

        public string ls(int depth)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Indent(depth)).Append("dir: ").Append(Name).AppendLine();

            for (int i = 0; i < Children.Count; i++)
            {
                IFileSystemObject child = Children[i];
                sb.Append(Indent(depth + 1)).Append(child.ls(depth+1));
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }

    public class File : IFileSystemObject
    {
        public string Name { get; set; }
        public Directory Parent { get; set; }
        public string contents { get ;set; } = "Empty File!";
        public File(string name, string fileExtension)
        {
            Name = name + "." + fileExtension;
        }

        public string ls(int depth) => new string(' ',depth * 2) +  Name;
    }
}


