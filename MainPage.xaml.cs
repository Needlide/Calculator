using Calculator.Views;
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
        public MainPage()
        {
            InitializeComponent();
        }

        private void nvTopLevelNav_Loaded(object sender, RoutedEventArgs e)
        {
            nvTopLevelNav.SelectedItem = nvTopLevelNav.MenuItems.ElementAt(1);
            contentFrame.Navigate(typeof(StandardCalculatorPage));
        }

        private void nvTopLevelNav_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if(args.IsSettingsInvoked)
            {
                nvTopLevelNav.IsBackButtonVisible = NavigationViewBackButtonVisible.Visible;
                contentFrame.Navigate(typeof(SettingsPage));
            }
            else if(args.InvokedItem is NavigationViewItem nvi)
            {
                switch(nvi.Tag)
                {
                    case "Standard":
                        nvTopLevelNav.IsBackButtonVisible = NavigationViewBackButtonVisible.Collapsed;
                        contentFrame.Navigate(typeof(StandardCalculatorPage));
                        break;
                }
            }
            //When items will be added to NV add code here
        }
    }
}
