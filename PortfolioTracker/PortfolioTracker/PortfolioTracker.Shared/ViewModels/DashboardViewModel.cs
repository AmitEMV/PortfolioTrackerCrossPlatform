using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using PortfolioTracker.Interfaces;
using PortfolioTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioTracker.ViewModels
{
    public class DashboardViewModel: ObservableObject
    {
        private readonly IFundsService FundsService = Ioc.Default.GetRequiredService<IFundsService>();
        private readonly IPortfolioService PortfolioService = Ioc.Default.GetRequiredService<IPortfolioService>();
        public IAsyncRelayCommand LoadStartupCommand { get; }

        private double totalValue;
        public double TotalValue
        {
            get => totalValue;
            set => SetProperty(ref totalValue, value);
        }

        private bool isLoading;
        public bool IsLoading
        {
            get => isLoading;
            set => SetProperty(ref isLoading, value);
        }

        private List<PortfolioSnapshot> portfolioSnapshots;
        public List<PortfolioSnapshot> PortfolioSnapshots
        {
            get => portfolioSnapshots;
            set => SetProperty(ref portfolioSnapshots, value);
        }

        public DashboardViewModel()
        {
            TotalValue = 0;
            IsLoading = true;
            PortfolioSnapshots = new List<PortfolioSnapshot>();
            LoadStartupCommand = new AsyncRelayCommand(LoadStartUpData);
        }

        private async Task GetTotalValueAsync()
        {
            TotalValue = await FundsService.GetTotalValueAsync();
        }

        private async Task LoadStartUpData()
        {
            await GetTotalValueAsync();
            await GetPortfolioSnapshotAsync();
            IsLoading = false;
        }

        private async Task GetPortfolioSnapshotAsync()
        {
            PortfolioSnapshots = await PortfolioService.GetPortfolioSnapshotAsync();
        }

    }
}
