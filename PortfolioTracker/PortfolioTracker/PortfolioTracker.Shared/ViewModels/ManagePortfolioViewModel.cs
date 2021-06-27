using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using PortfolioTracker.Interfaces;
using PortfolioTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTracker.ViewModels
{
    public class ManagePortfolioViewModel : ObservableObject
    {
        private readonly IFundsService FundsService = Ioc.Default.GetRequiredService<IFundsService>();
        private readonly IPortfolioService PortfolioService = Ioc.Default.GetRequiredService<IPortfolioService>();
        public IAsyncRelayCommand LoadStartupCommand { get; }

        private List<Funds> fundsList;
        public List<Funds> FundsList
        {
            get => fundsList;
            set => SetProperty(ref fundsList, value);
        }

        private List<PortfolioSnapshot> portfolioSnapshots;
        public List<PortfolioSnapshot> PortfolioSnapshots
        {
            get => portfolioSnapshots;
            set => SetProperty(ref portfolioSnapshots, value);
        }

        public ManagePortfolioViewModel()
        {
            FundsList = new List<Funds>();
            LoadStartupCommand = new AsyncRelayCommand(LoadStartUpData);
        }

        private async Task LoadStartUpData()
        {
            await GetFundsListAsync();
            await GetPortfolioSnapshotAsync();
        }

        private async Task GetFundsListAsync()
        {
            FundsList = await FundsService.GetFundsListAsync();
        }

        private async Task GetPortfolioSnapshotAsync()
        {
            PortfolioSnapshots = await PortfolioService.GetPortfolioSnapshotAsync();
        }
    }
}
