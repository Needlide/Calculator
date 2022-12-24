using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Calculator
{
    internal class SettingsController
    {
        #region Fields
        readonly FileStream _fileStream;
        long _fileLength = 0;
        #endregion

        #region Constructor
        internal SettingsController()
        {
            try
            {
                FileInfo settingsFile = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + '\\' + "settings.json");
                _fileStream = new FileStream(settingsFile.FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 131072, false);
                _fileLength = _fileStream.Length;
            }
            catch { }
        }
        #endregion

        #region TextBlock settings operations
        internal async Task SaveTextBlockSettingsAsync(TextBlock textBlock)
        {
            if (_fileStream.CanWrite)
            {
                byte[] objectInBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(textBlock));
                await _fileStream.WriteAsync(objectInBytes, ((int)_fileLength), objectInBytes.Length);
                await _fileStream.FlushAsync();
            }
        }

        internal async Task<TextBlock> LoadTextBlockSettingsAsync(string textBlockName)
        {
            try
            {
                List<FrameworkElement> textBlocks = new List<FrameworkElement>();
                byte[] objectInBytes = new byte[_fileStream.Length];

                if (_fileStream.CanRead && _fileStream.Length > 0)
                {
                    _fileStream.Read(objectInBytes, 0, ((int)_fileStream.Length)/*maybe zero cause _fileStream doesn't have inside stream from file*/);
                    await Task.Run(() => { textBlocks = JsonConvert.DeserializeObject<List<FrameworkElement>>(Encoding.UTF8.GetString(objectInBytes)); });
                }

                await _fileStream.FlushAsync();
                return (TextBlock)Task.FromResult(textBlocks.Find(x => x.Name.Equals(textBlockName))).Result;
            }
            catch { return Task.FromResult(new TextBlock()).Result; }
        }
        #endregion

        #region Button settings operations
        internal async Task SaveButtonSettingsAsync(Button button)
        {
            if(_fileStream.CanWrite)
            {
                byte[] objectInBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(button));
                await _fileStream.WriteAsync(objectInBytes, ((int)_fileLength), objectInBytes.Length);
                await _fileStream.FlushAsync();
            }
        }

        internal async Task<Button> LoadButtonSettingsAsync(string buttonName)
        {
            try
            {
                List<FrameworkElement> buttons = new List<FrameworkElement>();
                byte[] objectInBytes = new byte[_fileLength];

                if(_fileStream.CanRead && _fileStream.Length > 0)
                {
                    _fileStream.Read(objectInBytes, 0, ((int)_fileStream.Length));
                    await Task.Run(() => { buttons = JsonConvert.DeserializeObject<List<FrameworkElement>>(Encoding.UTF8.GetString(objectInBytes)); });
                }

                await _fileStream.FlushAsync();
                return (Button)Task.FromResult(buttons.Find(x => x.Name.Equals(buttonName))).Result;
            }
            catch { return Task.FromResult(new Button()).Result; }
        }
        #endregion
    }
}
