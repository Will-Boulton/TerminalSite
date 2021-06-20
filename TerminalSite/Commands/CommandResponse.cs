using System;
namespace TerminalSite.Commands
{
    /// <summary>
    /// Response to write to a new line in the commandline
    /// </summary>
    public class CommandResponse
    {
        public string Response { get; set;  }

        public bool AsMarkup { get; set; } = false;

        public CommandResponse(string response)
        {
            Response = response;
        }

        public  CommandResponse(AnnotatedURL url)
        {
            Response = url.URLString; AsMarkup = true;
        }
    }

    /// <summary>
    /// URL with annotation
    /// </summary>
    public class AnnotatedURL
    {
        public AnnotatedURL(string annotation, Uri URL)
        {
            Annotation = annotation;
            this.URL = URL;
        }

        private string Annotation { get; set; }

        private Uri URL { get; set; }

        public string URLString => $"<a href=\"{URL}\">{Annotation}</a>";
    }
}
