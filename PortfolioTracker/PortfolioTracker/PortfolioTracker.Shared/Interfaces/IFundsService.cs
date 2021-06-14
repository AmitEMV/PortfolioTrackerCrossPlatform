using PortfolioTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTracker.Interfaces
{
    public interface IFundsService
    {
        Task<double> GetTotalValueAsync();

        Task<ValueTrend[]> GetTotalValueTrendAsync();

        Task<List<FundPerformance>> GetFundPerformanceAsync(string API);

        Task<List<Funds>> GetFundsListAsync();
    }
}
