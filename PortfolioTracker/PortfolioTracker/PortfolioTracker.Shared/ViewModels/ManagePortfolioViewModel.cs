using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using PortfolioTracker.Interfaces;
using PortfolioTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace PortfolioTracker.ViewModels
{
    public class ManagePortfolioViewModel : ObservableObject
    {
        private readonly IFundsService FundsService = Ioc.Default.GetRequiredService<IFundsService>();
        private readonly IPortfolioService PortfolioService = Ioc.Default.GetRequiredService<IPortfolioService>();
        public IAsyncRelayCommand LoadStartupCommand { get; }
        public IAsyncRelayCommand AddNewFundCommand { get; }
        public IAsyncRelayCommand RemoveFundCommand { get; }

        private List<Funds> fundsList;
        public List<Funds> FundsList
        {
            get => fundsList;
            set => SetProperty(ref fundsList, value);
        }

        private DateTime purchasedDate;
        public DateTime PurchasedDate
        {
            get => purchasedDate;
            set => SetProperty(ref purchasedDate, value);
        }

        private string purchasedUnits;
        public string PurchasedUnits
        {
            get => purchasedUnits;
            set => SetProperty(ref purchasedUnits, value);
        }

        private IEnumerable<PortfolioSnapshot> portfolioSnapshots;
        public IEnumerable<PortfolioSnapshot> PortfolioSnapshots
        {
            get => portfolioSnapshots;
            set => SetProperty(ref portfolioSnapshots, value);
        }

        public ManagePortfolioViewModel()
        {
            FundsList = new List<Funds>();
            PurchasedDate = DateTime.Now;
            LoadStartupCommand = new AsyncRelayCommand(LoadStartUpData);
            AddNewFundCommand = new AsyncRelayCommand<Funds>(AddNewFundAsync);
            RemoveFundCommand = new AsyncRelayCommand<PortfolioSnapshot>(RemoveFundAsync);
        }

        public async Task LoadStartUpData()
        {
           FundsList =  await FundsService.GetFundsListAsync();
           PortfolioSnapshots = await PortfolioService.GetPortfolioSnapshotAsync();
        }

        private async Task AddNewFundAsync(Funds selectedFund)
        {
            bool success = await PortfolioService.AddFundToPortfolioAsync(new FundInfo
            {
                FundId = selectedFund.Id,
                FundName = selectedFund.FundName,
                PurchaseType = "LumpSum",
                PurchaseDate = PurchasedDate,
                NumberOfUnits = PurchasedUnits
            });

            if(success)
            {
                PortfolioSnapshots = await PortfolioService.GetPortfolioSnapshotAsync();
                await ShowStatusMessage(selectedFund.FundName, "successfully added to your portfolio.", "Success!");
            }
            else
            {
                await ShowStatusMessage(selectedFund.FundName, "could not be added to your portfolio.", "Oops, that didn't work :(");
            }

        }

        private async Task RemoveFundAsync(PortfolioSnapshot fundData)
        {
            bool success = await PortfolioService.RemoveFundFromFolio(fundData);

            if (success)
            {
                PortfolioSnapshots = PortfolioSnapshots.Where(fund => fund.FundId != fundData.FundId);
                await ShowStatusMessage(fundData.FundName, "removed from your portfolio.", "Success!");
            }
            else
            {
                await ShowStatusMessage(fundData.FundName, "could not removed from your portfolio.", "Oops, that didn't work :(");
            }
        }

        private async Task ShowStatusMessage(string fundName, string message, string status)
        {
            ContentDialog successDialog = new ContentDialog
            {
                Title =  status,
                Content = $"{fundName} {message}",
                CloseButtonText = "Ok"
            };

            await successDialog.ShowAsync();
        }
    }
}
