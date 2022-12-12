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
            if(!string.IsNullOrEmpty(EquationBlock.Text))
            try
            {
                HelperBlock.Text = $"1/{EquationBlock.Text}";
                EquationBlock.Text = (1 / Convert.ToDecimal(EquationBlock.Text)).ToString();
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
}
