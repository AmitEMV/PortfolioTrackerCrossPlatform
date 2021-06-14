using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using PortfolioTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PortfolioTracker.ViewModels
{
    public class DashboardViewModel: ObservableObject
    {
        private readonly IFundsService FundsService = Ioc.Default.GetRequiredService<IFundsService>();

        public DashboardViewModel()
        {
            TotalValue = "0";
            GetTotalValuesCommand = new AsyncRelayCommand(GetTotalValueAsync);
        }

        public IAsyncRelayCommand GetTotalValuesCommand { get; }

        private async Task GetTotalValueAsync()
        {
            double value = await FundsService.GetTotalValueAsync();
            TotalValue = value.ToString();
        }

        private string totalValue;
        public string TotalValue
        {
            get => totalValue;
            set => SetProperty(ref totalValue, value);
        }

    }
}
