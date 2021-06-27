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

#if __ANDROID__
    RootNavigationView.PaneDisplayMode = NavigationViewPaneDisplayMode.Auto;
#else
            RootNavigationView.PaneDisplayMode = NavigationViewPaneDisplayMode.Top;
#endif
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RootNavigationView.SelectedItem = DashboardItem;
            NavigationFrame.Navigate(typeof(DashboardView));
        }

        private void RootNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var clickedItem = (Windows.UI.Xaml.Controls.NavigationViewItem)args.SelectedItem;
            string itemTag = (string)clickedItem.Tag;

            switch (itemTag)
            {
                case "Dashboard":
                    NavigationFrame.Navigate(typeof(DashboardView));
                    break;

                case "Manage Portfolio":
                    NavigationFrame.Navigate(typeof(ManagePortfolioView));
                    break;
            }
        }
    }
}
