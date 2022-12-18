using Calculator.Controls;
using System;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Calculator.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StandardCalculatorPage : Page
    {
        #region Fields
        readonly EquationAnalyzer _equationAnalyzer = new EquationAnalyzer();
        Button invokerButton;
        TextBlock invokerTextBlock;
        #endregion

        #region Constructor
        public StandardCalculatorPage()
        {
            InitializeComponent();
        }
        #endregion

        #region Click events
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (EquationBlock.Text.Equals("FormatException") || EquationBlock.Text.Equals("OverflowException"))
                    EquationBlock.Text = decimal.Zero.ToString();
                switch (button.Content.ToString())
                {
                    case "0":
                        if (!EquationBlock.Text.StartsWith("0") && string.IsNullOrEmpty(EquationBlock.Text)) { EquationBlock.Text = "0"; }
                        else if (!string.IsNullOrEmpty(EquationBlock.Text) && !EquationBlock.Text.Equals("0")) { EquationBlock.Text += "0"; }
                        break;
                    case "1":
                        if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "1"; }
                        else { EquationBlock.Text += "1"; }
                        break;
                    case "2":
                        if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "2"; }
                        else { EquationBlock.Text += "2"; }
                        break;
                    case "3":
                        if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "3"; }
                        else { EquationBlock.Text += "3"; }
                        break;
                    case "4":
                        if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "4"; }
                        else { EquationBlock.Text += "4"; }
                        break;
                    case "5":
                        if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "5"; }
                        else { EquationBlock.Text += "5"; }
                        break;
                    case "6":
                        if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "6"; }
                        else { EquationBlock.Text += "6"; }
                        break;
                    case "7":
                        if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "7"; }
                        else { EquationBlock.Text += "7"; }
                        break;
                    case "8":
                        if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "8"; }
                        else { EquationBlock.Text += "8"; }
                        break;
                    case "9":
                        if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "9"; }
                        else { EquationBlock.Text += "9"; }
                        break;
                }
            }
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (EquationBlock.Text.Length != 0)
            {
                EquationBlock.Text = EquationBlock.Text.Substring(0, EquationBlock.Text.Length - 1);
            }
        }

        private void ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            EquationBlock.Text = decimal.Zero.ToString();
            if (HelperBlock.Text.Contains('='))
                HelperBlock.Text = string.Empty;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            EquationBlock.Text = decimal.Zero.ToString();
            HelperBlock.Text = string.Empty;
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            if (EquationBlock.Text.Length == 0) { EquationBlock.Text = "0."; }
            else if (!EquationBlock.Text.Contains(".")) { EquationBlock.Text += '.'; }
        }

        private void OneDivideX_Click(object sender, RoutedEventArgs e)
        {
            if (EquationBlock.Text.Contains('^'))
            {
                Pow();
                SetResult();
            }
            if (!string.IsNullOrEmpty(EquationBlock.Text))
            {
                try
                {
                    HelperBlock.Text = $"1/{EquationBlock.Text}";
                    EquationBlock.Text = (1 / Convert.ToDecimal(EquationBlock.Text)).ToString();
                }
                catch (FormatException)
                {
                    HelperBlock.Text = string.Empty;
                    EquationBlock.Text = "FormatException";
                }
                catch (OverflowException)
                {
                    HelperBlock.Text = string.Empty;

                    EquationBlock.Text = "OverflowException";
                }
            }
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (EquationBlock.Text.Contains('^'))
            {
                Pow();
                SetResult();
            }
            if (!string.IsNullOrEmpty(EquationBlock.Text) && string.IsNullOrEmpty(HelperBlock.Text))
            {
                try
                {
                    _equationAnalyzer.FirstNumber = Convert.ToDecimal(EquationBlock.Text);
                    _equationAnalyzer.Action = Action.Plus;
                    HelperBlock.Text = EquationBlock.Text + " +";
                    EquationBlock.Text = decimal.Zero.ToString();
                }
                catch (FormatException)
                {
                    HelperBlock.Text = string.Empty;
                    EquationBlock.Text = "FormatException";
                }
                catch (OverflowException)
                {
                    HelperBlock.Text = string.Empty;
                    EquationBlock.Text = "OverflowException";
                }
            }
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (EquationBlock.Text.Contains('^'))
            {
                Pow();
                SetResult();
            }
            if (!string.IsNullOrEmpty(EquationBlock.Text) && string.IsNullOrEmpty(HelperBlock.Text))
            {
                try
                {
                    _equationAnalyzer.FirstNumber = Convert.ToDecimal(EquationBlock.Text);
                    _equationAnalyzer.Action = Action.Minus;
                    HelperBlock.Text = EquationBlock.Text + " -";
                    EquationBlock.Text = decimal.Zero.ToString();
                }
                catch (FormatException)
                {
                    HelperBlock.Text = string.Empty;
                    EquationBlock.Text = "FormatException";
                }
                catch (OverflowException)
                {
                    HelperBlock.Text = string.Empty;
                    EquationBlock.Text = "OverflowException";
                }
            }
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            if (EquationBlock.Text.Contains('^'))
            {
                Pow();
                SetResult();
            }
            if (!string.IsNullOrEmpty(EquationBlock.Text) && string.IsNullOrEmpty(HelperBlock.Text))
            {
                try
                {
                    _equationAnalyzer.FirstNumber = Convert.ToDecimal(EquationBlock.Text);
                    _equationAnalyzer.Action = Action.Multiplication;
                    HelperBlock.Text = EquationBlock.Text + " *";
                    EquationBlock.Text = decimal.Zero.ToString();
                }
                catch (FormatException)
                {
                    HelperBlock.Text = string.Empty;
                    EquationBlock.Text = "FormatException";
                }
                catch (OverflowException)
                {
                    HelperBlock.Text = string.Empty;
                    EquationBlock.Text = "OverflowException";
                }
            }
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            if (EquationBlock.Text.Contains('^'))
            {
                Pow();
                SetResult();
            }
            if (!string.IsNullOrEmpty(EquationBlock.Text) && string.IsNullOrEmpty(HelperBlock.Text))
            {
                try
                {
                    _equationAnalyzer.FirstNumber = Convert.ToDecimal(EquationBlock.Text);
                    _equationAnalyzer.Action = Action.Division;
                    HelperBlock.Text = EquationBlock.Text + " /";
                    EquationBlock.Text = decimal.Zero.ToString();
                }
                catch (FormatException)
                {
                    HelperBlock.Text = string.Empty;
                    EquationBlock.Text = "FormatException";
                }
                catch (OverflowException)
                {
                    HelperBlock.Text = string.Empty;
                    EquationBlock.Text = "OverflowException";
                }
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (EquationBlock.Text.Contains('^'))
            {
                Pow();
                SetResult();
            }
            else if (!string.IsNullOrEmpty(EquationBlock.Text) && _equationAnalyzer.Action != Action.None)
            {
                try
                {
                    _equationAnalyzer.SecondNumber = Convert.ToDecimal(EquationBlock.Text);
                    HelperBlock.Text += $" {EquationBlock.Text} =";
                    SetResult();
                }
                catch (FormatException)
                {
                    EquationBlock.Text = "FormatException";
                }
                catch (OverflowException)
                {
                    EquationBlock.Text = "OverflowException";
                }
            }
        }

        private void PowerToTwo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _equationAnalyzer.FirstNumber = Convert.ToDecimal(EquationBlock.Text);
                _equationAnalyzer.SecondNumber = 2m;
                _equationAnalyzer.Action = Action.Power;
                HelperBlock.Text = EquationBlock.Text + "^2";
                EquationBlock.Text = decimal.Zero.ToString();
            }
            catch (FormatException)
            {
                HelperBlock.Text = string.Empty;
                EquationBlock.Text = "FormatException";
            }
            catch (OverflowException)
            {
                HelperBlock.Text = string.Empty;
                EquationBlock.Text = "OverflowException";
            }
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            if (EquationBlock.Text.Contains('^'))
            {
                Pow();
                SetResult();
            }
            if (!string.IsNullOrEmpty(EquationBlock.Text) && string.IsNullOrEmpty(HelperBlock.Text))
            {
                try
                {
                    _equationAnalyzer.FirstNumber = Convert.ToDecimal(EquationBlock.Text);
                    _equationAnalyzer.Action = Action.Percentage;
                    HelperBlock.Text = EquationBlock.Text + " %";
                    EquationBlock.Text = decimal.Zero.ToString();
                }
                catch (FormatException)
                {
                    HelperBlock.Text = string.Empty;
                    EquationBlock.Text = "FormatException";
                }
                catch (OverflowException)
                {
                    HelperBlock.Text = string.Empty;
                    EquationBlock.Text = "OverflowException";
                }
            }
        }

        private void InvertNumber_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(EquationBlock.Text))
            {
                if (EquationBlock.Text.Contains('-'))
                    EquationBlock.Text = EquationBlock.Text.Substring(1);
                else
                    EquationBlock.Text = '-' + EquationBlock.Text;
            }
        }

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            _equationAnalyzer.FirstNumber = Convert.ToDecimal(EquationBlock.Text);
            _equationAnalyzer.Action = Action.Root;
            SetResult();
        }

        private void CopyFlyoutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataPackage data = new DataPackage();
            data.SetText(EquationBlock.Text);
            Clipboard.SetContent(data);
        }

        private void Element_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            if (sender.GetType() == typeof(Button))
                invokerButton = sender as Button;
            else if (sender.GetType() == typeof(TextBlock))
                invokerTextBlock = sender as TextBlock;
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        private async void Appearance_Click(object sender, RoutedEventArgs e)
        {
            if (invokerButton != null)
            {
                AppearanceWindowControl window = new AppearanceWindowControl(invokerButton);
                window.XamlRoot = XamlRoot;
                await window.ShowAsync();
            }
            else if(invokerTextBlock != null)
            {
                AppearanceWindowControl window = new AppearanceWindowControl(invokerTextBlock);
                window.XamlRoot = XamlRoot;
                await window.ShowAsync();
            }
        }
        #endregion

        #region Methods
        private void Pow()
        {
            _equationAnalyzer.Action = Action.Power;
            _equationAnalyzer.FirstNumber = Convert.ToDecimal(EquationBlock.Text.Substring(0, EquationBlock.Text.IndexOf('^')));
            _equationAnalyzer.SecondNumber = Convert.ToDecimal(EquationBlock.Text.Substring(EquationBlock.Text.IndexOf('^') + 1));
        }

        private void SetResult()
        {
            EquationBlock.Text = _equationAnalyzer.Calculate().ToString();
            if (EquationBlock.Text.Length > 10)
                EquationBlock.FontSize = 50;
            else
                EquationBlock.FontSize = 80;
            _equationAnalyzer.Action = Action.None;
            _equationAnalyzer.FirstNumber = decimal.Zero;
            _equationAnalyzer.SecondNumber = decimal.Zero;
        }

        #endregion

        #region MethodsAttachedToPage
        private void page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height <= 800)
            {
                foreach (Button button in PanelWithButtons.Children.Cast<Button>())
                {
                    button.FontSize = 20;
                }
            }
            else if (e.NewSize.Height > 800)
            {
                foreach (Button button in PanelWithButtons.Children.Cast<Button>())
                {
                    button.FontSize = 28;
                }
            }
        }

        private void page_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Number0:
                case Windows.System.VirtualKey.NumberPad0:
                    if (!EquationBlock.Text.StartsWith("0") && string.IsNullOrEmpty(EquationBlock.Text)) { EquationBlock.Text = "0"; }
                    else if (!string.IsNullOrEmpty(EquationBlock.Text) && !EquationBlock.Text.Equals("0")) { EquationBlock.Text += "0"; }
                    break;
                case Windows.System.VirtualKey.Number1:
                case Windows.System.VirtualKey.NumberPad1:
                    if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "1"; }
                    else { EquationBlock.Text += "1"; }
                    break;
                case Windows.System.VirtualKey.Number2:
                case Windows.System.VirtualKey.NumberPad2:
                    if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "2"; }
                    else { EquationBlock.Text += "2"; }
                    break;
                case Windows.System.VirtualKey.Number3:
                case Windows.System.VirtualKey.NumberPad3:
                    if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "3"; }
                    else { EquationBlock.Text += "3"; }
                    break;
                case Windows.System.VirtualKey.Number4:
                case Windows.System.VirtualKey.NumberPad4:
                    if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "4"; }
                    else { EquationBlock.Text += "4"; }
                    break;
                case Windows.System.VirtualKey.Number5:
                case Windows.System.VirtualKey.NumberPad5:
                    if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "5"; }
                    else { EquationBlock.Text += "5"; }
                    break;
                case Windows.System.VirtualKey.Number6:
                case Windows.System.VirtualKey.NumberPad6:
                    if (!EquationBlock.Text.Contains('^'))
                    {
                        if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "6"; }
                        else { EquationBlock.Text += "6"; }
                    }
                    break;
                case Windows.System.VirtualKey.Number7:
                case Windows.System.VirtualKey.NumberPad7:
                    if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "7"; }
                    else { EquationBlock.Text += "7"; }
                    break;
                case Windows.System.VirtualKey.Number8:
                case Windows.System.VirtualKey.NumberPad8:
                    if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "8"; }
                    else { EquationBlock.Text += "8"; }
                    break;
                case Windows.System.VirtualKey.Number9:
                case Windows.System.VirtualKey.NumberPad9:
                    if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "9"; }
                    else { EquationBlock.Text += "9"; }
                    break;
                case Windows.System.VirtualKey.Decimal:
                    if (EquationBlock.Text.Length == 0) { EquationBlock.Text = "0."; }
                    else if (!EquationBlock.Text.Contains(".")) { EquationBlock.Text += '.'; }
                    break;
                case Windows.System.VirtualKey.Divide:
                    Divide_Click(null, null);
                    break;
                case Windows.System.VirtualKey.Multiply:
                    Multiplication_Click(null, null);
                    break;
                case Windows.System.VirtualKey.Subtract:
                    Minus_Click(null, null);
                    break;
                case Windows.System.VirtualKey.Add:
                    Plus_Click(null, null);
                    break;
            }
        }

        private void page_ProcessKeyboardAccelerators(UIElement sender, Windows.UI.Xaml.Input.ProcessKeyboardAcceleratorEventArgs args)
        {
            if (args.Key.Equals(Windows.System.VirtualKey.Number6) && args.Modifiers.Equals(Windows.System.VirtualKeyModifiers.Shift))
            {
                if (!string.IsNullOrEmpty(EquationBlock.Text))
                {
                    EquationBlock.Text += " ^ ";
                }
            }
            if (args.Key.Equals(Windows.System.VirtualKey.C) && args.Modifiers.Equals(Windows.System.VirtualKeyModifiers.Control))
            {
                if (!string.IsNullOrEmpty(EquationBlock.Text))
                {
                    DataPackage data = new DataPackage();
                    data.SetText(EquationBlock.Text);
                    Clipboard.SetContent(data);
                }
            }
            if (args.Key.Equals(Windows.System.VirtualKey.V) && args.Modifiers.Equals(Windows.System.VirtualKeyModifiers.Control))
            {
                EquationBlock.Text = Clipboard.GetContent().GetTextAsync().AsTask().GetAwaiter().GetResult();
            }
        }

        #endregion
    }
}
