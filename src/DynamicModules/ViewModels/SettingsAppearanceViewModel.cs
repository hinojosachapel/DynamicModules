using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Prism.Mvvm;
using FirstFloor.ModernUI.Presentation;
using DM.Demo.Constants;

namespace DM.Demo.ViewModels
{
    /// <summary>
    /// A simple view model for configuring theme, font and accent colors.
    /// </summary>
    public class SettingsAppearanceViewModel : BindableBase
    {
        private const string FontSmall = "small";
        private const string FontLarge = "large";

        // 20 accent colors from Windows Phone 8
        private Color[] wpAccentColors = new Color[]{
            Color.FromRgb(0xa4, 0xc4, 0x00),   // lime
            Color.FromRgb(0x60, 0xa9, 0x17),   // green
            Color.FromRgb(0x00, 0x8a, 0x00),   // emerald
            Color.FromRgb(0x00, 0xab, 0xa9),   // teal
            Color.FromRgb(0x1b, 0xa1, 0xe2),   // cyan
            Color.FromRgb(0x00, 0x50, 0xef),   // cobalt
            Color.FromRgb(0x6a, 0x00, 0xff),   // indigo
            Color.FromRgb(0xaa, 0x00, 0xff),   // violet
            Color.FromRgb(0xf4, 0x72, 0xd0),   // pink
            Color.FromRgb(0xd8, 0x00, 0x73),   // magenta
            Color.FromRgb(0xa2, 0x00, 0x25),   // crimson
            Color.FromRgb(0xe5, 0x14, 0x00),   // red
            Color.FromRgb(0xfa, 0x68, 0x00),   // orange
            Color.FromRgb(0xf0, 0xa3, 0x0a),   // amber
            Color.FromRgb(0xe3, 0xc8, 0x00),   // yellow
            Color.FromRgb(0x82, 0x5a, 0x2c),   // brown
            Color.FromRgb(0x6d, 0x87, 0x64),   // olive
            Color.FromRgb(0x64, 0x76, 0x87),   // steel
            Color.FromRgb(0x76, 0x60, 0x8a),   // mauve
            Color.FromRgb(0x87, 0x79, 0x4e),   // taupe
        };

        private Color selectedAccentColor;
        private LinkCollection themes = new LinkCollection();
        private Link selectedTheme;
        private string selectedFontSize;

        public SettingsAppearanceViewModel()
        {
            // add the default themes
            //this.themes.Add(new Link { DisplayName = "light", Source = AppearanceManager.LightThemeSource });
            //this.themes.Add(new Link { DisplayName = "dark", Source = AppearanceManager.DarkThemeSource });

            // add additional themes
            this.themes.Add(new Link { DisplayName = "dynamic modules", Source = new Uri(ThemesPath.DM, UriKind.Relative) });
            this.themes.Add(new Link { DisplayName = "light", Source = new Uri(ThemesPath.Light, UriKind.Relative) });
            this.themes.Add(new Link { DisplayName = "dark", Source = new Uri(ThemesPath.Dark, UriKind.Relative) });
            this.themes.Add(new Link { DisplayName = "light bing image", Source = new Uri(ThemesPath.LightBingImage, UriKind.Relative) });
            this.themes.Add(new Link { DisplayName = "dark bing image", Source = new Uri(ThemesPath.DarkBingImage, UriKind.Relative) });
            this.themes.Add(new Link { DisplayName = "windows 10", Source = new Uri(ThemesPath.Windows10, UriKind.Relative) });
            this.themes.Add(new Link { DisplayName = "mac osx", Source = new Uri(ThemesPath.MacOSX, UriKind.Relative) });

            this.SelectedFontSize = AppearanceManager.Current.FontSize == FontSize.Large ? FontLarge : FontSmall;
            SyncThemeAndColor();

            AppearanceManager.Current.PropertyChanged += OnAppearanceManagerPropertyChanged;
        }

        private void SyncThemeAndColor()
        {
            // synchronizes the selected viewmodel theme with the actual theme used by the appearance manager.
            this.SelectedTheme = this.themes.FirstOrDefault(l => l.Source.Equals(AppearanceManager.Current.ThemeSource));

            // and make sure accent color is up-to-date
            this.SelectedAccentColor = AppearanceManager.Current.AccentColor;
        }

        private void OnAppearanceManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ThemeSource" || e.PropertyName == "AccentColor")
            {
                SyncThemeAndColor();
            }
        }

        public LinkCollection Themes
        {
            get { return this.themes; }
        }

        public string[] FontSizes
        {
            get { return new string[] { FontSmall, FontLarge }; }
        }

        public Color[] AccentColors
        {
            get { return this.wpAccentColors; }
        }

        public Link SelectedTheme
        {
            get { return this.selectedTheme; }
            set
            {
                if (this.selectedTheme != value)
                {
                    SetProperty(ref selectedTheme, value);

                    // and update the actual theme
                    AppearanceManager.Current.ThemeSource = value.Source;
                }
            }
        }

        public string SelectedFontSize
        {
            get { return this.selectedFontSize; }
            set
            {
                if (this.selectedFontSize != value)
                {
                    SetProperty(ref selectedFontSize, value);

                    //AppearanceManager.Current.FontSize = value == FontLarge ? FontSize.Large : FontSize.Small;
                    //RH
                    Application.Current.Resources[AppearanceManager.KeyDefaultFontSize] = value == FontSmall ? 13D : 16D;
                    Application.Current.Resources[AppearanceManager.KeyFixedFontSize] = value == FontSmall ? 12.667D : 16.333D;
                }
            }
        }

        public Color SelectedAccentColor
        {
            get { return this.selectedAccentColor; }
            set
            {
                if (this.selectedAccentColor != value)
                {
                    SetProperty(ref selectedAccentColor, value);
                    AppearanceManager.Current.AccentColor = value;
                }
            }
        }
    }
}
