using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TerminalSite.Shared;

namespace TerminalSite.Controllers
{
    public  class ThemeController : INotifyPropertyChanged
    {
        private ComponentBase _component;

        private  Theme currentTheme { get; set;} = Theme.Dark;

        public  string SelectedTheme { get => ThemeClasses[currentTheme];}
        

        public  void SetTheme(Theme newTheme)
        {
            currentTheme = newTheme;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedTheme"));
        }

        private  readonly Dictionary<Theme, string> ThemeClasses = new Dictionary<Theme, string>() { { Theme.Dark, "dark" }, { Theme.Light, "light" } };

        public  readonly Dictionary<string, Theme> ThemeNames = new Dictionary<string, Theme>()
        {
            { "light",Theme.Light },
            { "dark",Theme.Dark }
        };

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public enum Theme
    {
        Dark,
        Light
    }
}
