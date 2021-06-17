using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalSite.Shared.TerminalResponses
{
    public interface ITerminalResponse
    {
        public RenderFragment Render();
    }
}
