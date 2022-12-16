using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Calculator.Controls
{
    public sealed partial class AppearanceWindowControl : ContentDialog
    {
        readonly Control invoker;
        public AppearanceWindowControl(Control invoker)
        {
            InitializeComponent();
            this.invoker = invoker;
            Title = invoker.GetType().Name;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ApplyAppearance();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Hide();
        }

        private void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAppearance();
        }

        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            ApplyAppearance();
        }

        private void LoadAppearance()
        {
            if (invoker != null)
            {
                FontSizeBox.Text = invoker.FontSize.ToString();
                FontFamilyComboBox.SelectedItem = invoker.FontFamily.ToString();
                try
                {
                    string ForegroundBrushColorWithoutHash = invoker.Foreground.ToString().Substring(1);
                    FontColorPicker.Color = Windows.UI.Color.FromArgb(Convert.ToByte(ForegroundBrushColorWithoutHash.Substring(0, 2), 16),
                    Convert.ToByte(ForegroundBrushColorWithoutHash.Substring(2, 2), 16),
                    Convert.ToByte(ForegroundBrushColorWithoutHash.Substring(4, 2), 16),
                    Convert.ToByte(ForegroundBrushColorWithoutHash.Substring(6, 2), 16));

                    string BackgroundBrushColorWithoutHash = invoker.Background.ToString().Substring(1);
                    BackgroundColorPicker.Color = Windows.UI.Color.FromArgb(Convert.ToByte(BackgroundBrushColorWithoutHash.Substring(0, 2), 16),
                    Convert.ToByte(BackgroundBrushColorWithoutHash.Substring(2, 2), 16),
                    Convert.ToByte(BackgroundBrushColorWithoutHash.Substring(4, 2), 16),
                    Convert.ToByte(BackgroundBrushColorWithoutHash.Substring(6, 2), 16));

                    string BorderBrushColorWithoutHash = invoker.BorderBrush.ToString().Substring(1);
                    BorderColorPicker.Color = Windows.UI.Color.FromArgb(Convert.ToByte(BorderBrushColorWithoutHash.Substring(0, 2), 16),
                    Convert.ToByte(BorderBrushColorWithoutHash.Substring(2, 2), 16),
                    Convert.ToByte(BorderBrushColorWithoutHash.Substring(4, 2), 16),
                    Convert.ToByte(BorderBrushColorWithoutHash.Substring(6, 2), 16));
                }
                catch { }

                BorderThicknessBox.Text = invoker.BorderThickness.Left.ToString() + ','
                + invoker.BorderThickness.Top.ToString() + ','
                + invoker.BorderThickness.Right.ToString() + ','
                + invoker.BorderThickness.Bottom;

            }
        }

        private void ApplyAppearance()
        {
            if (invoker != null)
            {
                try
                {
                    invoker.FontSize = Convert.ToDouble(FontSizeBox.Text);
                    invoker.FontFamily = (FontFamily)FontFamilyComboBox.SelectedValue;
                    invoker.Foreground = new SolidColorBrush(FontColorPicker.Color);
                    invoker.Background = new SolidColorBrush(BackgroundColorPicker.Color);
                    invoker.BorderBrush = new SolidColorBrush(BorderColorPicker.Color);
                    string[] thicknessValues = BorderThicknessBox.Text.Split(',');
                    if (thicknessValues.Length == 4)
                    {
                        invoker.BorderThickness = new Thickness(Convert.ToDouble(thicknessValues[0]),
                        Convert.ToDouble(thicknessValues[1]), Convert.ToDouble(thicknessValues[2]), Convert.ToDouble(thicknessValues[3]));
                    }
                }
                catch { }
            }
        }
    }
}
