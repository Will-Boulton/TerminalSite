using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TerminalSite.Shared;

namespace TerminalSite.Controllers
{
    /// <summary>
    /// Class used to control the currently selected theme applied to the site
    /// </summary>
    public  class ThemeController : INotifyPropertyChanged
    {
        private readonly string STORAGE_KEY = "theme";

        /// <summary>
        /// local storage service used to cache the selected theme in the browser's local storage
        /// </summary>
        ISyncLocalStorageService _localStorageService;

        /// <summary>
        /// Construct a new theme controller
        /// </summary>
        /// <param name="localStorageService"></param>
        public ThemeController(ISyncLocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
            if (localStorageService.ContainKey(STORAGE_KEY))
            {
                string cookieTheme = localStorageService.GetItemAsString(STORAGE_KEY);
                if (ThemeNames.TryGetValue(cookieTheme, out Theme initTheme))
                {
                    SetTheme(initTheme);
                }
                
            }
            StoreSelectedTheme();
        }

        /// <summary>
        /// Store the currently selected theme in the browser local storage
        /// </summary>
        private void StoreSelectedTheme() => _localStorageService.SetItemAsString(STORAGE_KEY, SelectedTheme);

        /// <summary>
        /// Currently selected theme
        /// </summary>
        public  Theme currentTheme { get; set;} = Theme.Dark;

        /// <summary>
        /// Currently selected theme css classname
        /// </summary>
        public  string SelectedTheme { get => ThemeClasses[currentTheme];}

        /// <summary>
        /// Event triggered to notify any components that the theme has changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Set the theme, 
        /// </summary>
        /// <param name="newTheme"></param>
        public void SetTheme(Theme newTheme)
        {
            currentTheme = newTheme;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedTheme"));
            StoreSelectedTheme();
        }

        /// <summary>
        /// CSS class names for each theme
        /// </summary>
        private static readonly Dictionary<Theme, string> ThemeClasses = new Dictionary<Theme, string>() { { Theme.Dark, "dark" }, { Theme.Light, "light" } };

        /// <summary>
        /// Names for each theme
        /// </summary>
        public static readonly Dictionary<string, Theme> ThemeNames = new Dictionary<string, Theme>()
        {
            { "light",Theme.Light },
            { "dark",Theme.Dark }
        };

        
    }

    public enum Theme
    {
        Dark,
        Light
    }
}
