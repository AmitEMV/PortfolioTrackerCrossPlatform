using Microsoft.Extensions.DependencyInjection;
using PortfolioTracker.ViewModels;
using PortfolioTracker.Views;
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

namespace PortfolioTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
#if __ANDROID__ || __IOS__
    RootNavigationView.PaneDisplayMode = NavigationViewPaneDisplayMode.Left;
#else
            RootNavigationView.PaneDisplayMode = NavigationViewPaneDisplayMode.Top;
#endif
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RootNavigationView.SelectedItem = DashboardItem;
            NavigationFrame.Navigate(typeof(DashboardView));
        }
    }
}
