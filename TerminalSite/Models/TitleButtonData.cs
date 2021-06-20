using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalSite.Models
{
    public class TitleButtonData
    {
        public string Website { get; init; }

        public string URL { get; init; }
        public TitleButtonData(string website, string url)
        {
            Website = website;
            URL = url;
        }
    }
}
