using CollectionViewOrientationError.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using C4S.MobileApp.ViewModels;
using C4S.MobileApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionViewOrientationError.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Mainpage, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Mainpage:
                        MenuPages.Add(id, new NavigationPage(new PortfolioElementePage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}