using C4S.Model;
using C4S.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace C4S.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PortfolioElementePage : ContentPage
    {
        PortfolioElementeViewModel viewModel = new PortfolioElementeViewModel();

        public PortfolioElementePage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.PortfolioElemente.Count == 0)
                viewModel.LoadPortfolioElementeCommand.Execute(null);
        }
    }
}