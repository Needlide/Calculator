using Microsoft.Graphics.Canvas.Text;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Calculator.Controls
{
    public sealed partial class AppearanceWindowControl : ContentDialog
    {
        #region Fields
        readonly Button invoker;
        readonly TextBlock textBlock;
        readonly SettingsController _settingsController = new SettingsController();
        #endregion

        #region Constructors
        public AppearanceWindowControl(Button invoker)
        {
            InitializeComponent();
            this.invoker = invoker;
            DefaultButton = ContentDialogButton.Primary;
            Title = invoker.GetType().Name;
            FontFamilyComboBox.ItemsSource = SetComboBoxSource();
        }

        public AppearanceWindowControl(TextBlock textBlock)
        {
            InitializeComponent();
            this.textBlock = textBlock;
            Title = textBlock.GetType().Name;
            FontFamilyComboBox.ItemsSource = SetComboBoxSource();
            BackgroundColorPicker.Visibility = Visibility.Collapsed;
            BorderColorPicker.Visibility = Visibility.Collapsed;
            BorderThicknessBox.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region Button clicks
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ApplyAppearance();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Hide();
        }
        #endregion

        #region ContentDialog events
        private void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAppearance();
        }
        #endregion

        #region Methods
        private void LoadAppearance()
        {
            if (invoker != null)
            {
                FontSizeBox.Text = invoker.FontSize.ToString();

                try
                {
                    for (int i = 0; i < FontFamilyComboBox.Items.Count; i++)
                    {
                        FontFamily family = FontFamilyComboBox.Items[i] as FontFamily;
                        if (family.Source.Equals(invoker.FontFamily.Source))
                            FontFamilyComboBox.SelectedIndex = i;
                    }
                    if (invoker.Foreground is SolidColorBrush fontBrush)
                        FontColorPicker.Color = fontBrush.Color;

                    if (invoker.Background is SolidColorBrush backgroundBrush)
                        BackgroundColorPicker.Color = backgroundBrush.Color;

                    if (invoker.BorderBrush is SolidColorBrush borderBrush)
                        BorderColorPicker.Color = borderBrush.Color;
                }
                catch { }

                BorderThicknessBox.Text = invoker.BorderThickness.Left.ToString() + ','
                + invoker.BorderThickness.Top.ToString() + ','
                + invoker.BorderThickness.Right.ToString() + ','
                + invoker.BorderThickness.Bottom;

            }
            else if (textBlock != null)
            {
                FontSizeBox.Text = textBlock.FontSize.ToString();
                try
                {
                    for (int i = 0; i < FontFamilyComboBox.Items.Count; i++)
                    {
                        FontFamily family = FontFamilyComboBox.Items[i] as FontFamily;
                        if (family.Source.Equals(textBlock.FontFamily.Source))
                            FontFamilyComboBox.SelectedIndex = i;
                    }
                    if (textBlock.Foreground is SolidColorBrush fontBrush)
                        FontColorPicker.Color = fontBrush.Color;
                }
                catch { }
            }
        }

        private async void ApplyAppearance()
        {
            if (invoker != null)
            {
                try
                {
                    invoker.FontSize = Convert.ToDouble(FontSizeBox.Text);
                    invoker.FontFamily = (FontFamily)FontFamilyComboBox.SelectedItem;
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
            else if (textBlock != null)
            {
                textBlock.FontSize = Convert.ToDouble(FontSizeBox.Text);
                textBlock.FontFamily = (FontFamily)FontFamilyComboBox.SelectedItem;
                try
                {
                    textBlock.Foreground = new SolidColorBrush(FontColorPicker.Color);
                    await _settingsController.SaveTextBlockSettingsAsync(textBlock);
                }
                catch { }
            }
        }

        private List<FontFamily> SetComboBoxSource()
        {
            List<FontFamily> fonts = new List<FontFamily>();
            foreach (string fontName in CanvasTextFormat.GetSystemFontFamilies())
            {
                fonts.Add(new FontFamily(fontName));
            }
            return fonts;
        }
        #endregion
    }
}
