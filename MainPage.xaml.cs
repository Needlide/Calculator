using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        EquationAnalyzer _equationAnalyzer = new EquationAnalyzer();
        public MainPage()
        {
            InitializeComponent();
        }

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (EquationBlock.Text.Equals("FormatException") || EquationBlock.Text.Equals("OverflowException"))
                    EquationBlock.Text = string.Empty;
                switch (button.Content.ToString())
                {
                    case "0":
                        if(!EquationBlock.Text.StartsWith("0") && string.IsNullOrEmpty(EquationBlock.Text)) { EquationBlock.Text = "0"; }
                        else if(!string.IsNullOrEmpty(EquationBlock.Text) && !EquationBlock.Text.Equals("0")) { EquationBlock.Text += "0";}
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
            if(EquationBlock.Text.Length != 0)
            {
                EquationBlock.Text = EquationBlock.Text.Substring(0, EquationBlock.Text.Length - 1);
            }
        }

        private void ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            EquationBlock.Text = string.Empty;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            EquationBlock.Text = string.Empty;
            HelperBlock.Text = string.Empty;
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            if(EquationBlock.Text.Length == 0)
            {
                EquationBlock.Text = "0.";
            }
            else if(!EquationBlock.Text.Contains(".")) { EquationBlock.Text += '.'; }
        }

        private void OneDivideX_Click(object sender, RoutedEventArgs e)
        {
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
            if (!string.IsNullOrEmpty(EquationBlock.Text) && string.IsNullOrEmpty(HelperBlock.Text))
            {
                try
                {
                    _equationAnalyzer.FirstNumber = Convert.ToDecimal(EquationBlock.Text);
                    _equationAnalyzer.Action = Action.Plus;
                    HelperBlock.Text = EquationBlock.Text + " +";
                    EquationBlock.Text = string.Empty;
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
            if (!string.IsNullOrEmpty(EquationBlock.Text) && string.IsNullOrEmpty(HelperBlock.Text))
            {
                try
                {
                    _equationAnalyzer.FirstNumber = Convert.ToDecimal(EquationBlock.Text);
                    _equationAnalyzer.Action = Action.Minus;
                    HelperBlock.Text = EquationBlock.Text + " -";
                    EquationBlock.Text = string.Empty;
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
            if (!string.IsNullOrEmpty(EquationBlock.Text) && string.IsNullOrEmpty(HelperBlock.Text))
            {
                try
                {
                    _equationAnalyzer.FirstNumber = Convert.ToDecimal(EquationBlock.Text);
                    _equationAnalyzer.Action = Action.Multiplication;
                    HelperBlock.Text = EquationBlock.Text + " *";
                    EquationBlock.Text = string.Empty;
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
            if (!string.IsNullOrEmpty(EquationBlock.Text) && string.IsNullOrEmpty(HelperBlock.Text))
            {
                try
                {
                    _equationAnalyzer.FirstNumber = Convert.ToDecimal(EquationBlock.Text);
                    _equationAnalyzer.Action = Action.Division;
                    HelperBlock.Text = EquationBlock.Text + " /";
                    EquationBlock.Text = string.Empty;
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
            if(!string.IsNullOrEmpty(EquationBlock.Text) && _equationAnalyzer.Action != Action.None)
            {
                try
                {
                    _equationAnalyzer.SecondNumber = Convert.ToDecimal(EquationBlock.Text);
                    HelperBlock.Text += $" {EquationBlock.Text} =";
                    EquationBlock.Text = _equationAnalyzer.Calculate().ToString();
                    _equationAnalyzer.Action = Action.None;
                    _equationAnalyzer.FirstNumber = decimal.Zero;
                    _equationAnalyzer.SecondNumber = decimal.Zero;
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
                    if (EquationBlock.Text.Equals("0")) { EquationBlock.Text = "6"; }
                    else { EquationBlock.Text += "6"; }
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
            }
        }
    }
}
