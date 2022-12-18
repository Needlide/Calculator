using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace Calculator
{
    internal class SettingsController
    {
        readonly ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        #region TextBlock settings operations
        internal Task SaveTextBlockSettings(TextBlock textBlock)
        {
            ApplicationDataCompositeValue textBlockSettings = new ApplicationDataCompositeValue()
            {
                ["FontSize"] = textBlock.FontSize,
                ["FontFamily"] = textBlock.FontFamily,
                ["FontColor"] = textBlock.Foreground
            };
            localSettings.Values[textBlock.Name] = textBlockSettings;

            return Task.CompletedTask;
        }

        internal Task<ApplicationDataCompositeValue> LoadTextBlockSettings(string textBlockName)
        {
            return Task<ApplicationDataCompositeValue>.Factory.StartNew(() => GetTextBlockSettings(textBlockName));
        }

        private ApplicationDataCompositeValue GetTextBlockSettings(string textBlockName)
        {
            return (ApplicationDataCompositeValue)localSettings.Values[textBlockName];
        }
        #endregion

        #region Button settings operations
        internal Task SaveButtonSettings(Button button)
        {
            ApplicationDataCompositeValue buttonSettings = new ApplicationDataCompositeValue()
            {
                ["FontSize"] = button.FontSize,
                ["FontFamily"] = button.FontFamily,
                ["FontColor"] = button.Foreground,
                ["BackgroundColor"] = button.Background,
                ["BorderColor"] = button.BorderBrush,
                ["BorderThickness"] = button.BorderThickness
            };
            localSettings.Values[button.Name] = buttonSettings;
            return Task.CompletedTask;
        }

        internal Task<ApplicationDataCompositeValue> LoadButtonSettings(string buttonName)
        {
            return Task<ApplicationDataCompositeValue>.Factory.StartNew(() => GetButtonSettings(buttonName));
        }

        private ApplicationDataCompositeValue GetButtonSettings(string buttonName)
        {
            return (ApplicationDataCompositeValue)localSettings.Values[buttonName];
        }
        #endregion
    }
}
