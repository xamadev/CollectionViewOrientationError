using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using C4S.MobileApp.Views;
using C4S.Model;
using System.Collections.Generic;
using System.Linq;
using MvvmHelpers;
using Xamarin.Essentials;

namespace C4S.MobileApp.ViewModels
{
    public class PortfolioElementeViewModel : BaseViewModel
    {
        public ObservableRangeCollection<PortfolioElement> PortfolioElemente { get; set; } = new ObservableRangeCollection<PortfolioElement>();
        public Command LoadPortfolioElementeCommand { get; set; }

        public PortfolioElementeViewModel()
        {
            LoadPortfolioElementeCommand = new Command(async () => await ExecuteLoadPortfolioElementeCommand());
        }

        async Task ExecuteLoadPortfolioElementeCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                MainThread.BeginInvokeOnMainThread(() => PortfolioElemente.Clear());

                var portfolioElemente = new List<PortfolioElement>();

                for (int i = 0; i < 15; i++)
                {
                    portfolioElemente.Add(new PortfolioElement
                    {
                        Bezeichnung = "Test"
                    });
                }




                MainThread.BeginInvokeOnMainThread(() => PortfolioElemente.AddRange(portfolioElemente));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}