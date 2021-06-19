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

        public void AddChild(IFileSystemObject d)
        {
            Children.Add(d);
            d.Parent = this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Name);
            sb.AppendLine();
            for (int i = 0; i < Children.Count; i++)
            {
                IFileSystemObject child = Children[i];
                sb.Append("+");

                string row = i + 1 % Children.Count == 0 ? " " : "|";

                string[] childString = child.ToString().Split(Environment.NewLine);

                for (int j = 0; j < childString.Length; j++)
                {
                    sb.Append(j == 0 ? $"{childString[j]}" : $"{row}  |----{childString[j]}");

                    if(j != childString.Length -1)
                        sb.AppendLine();
                }
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

        public override string ToString() => Name;
    }
}


