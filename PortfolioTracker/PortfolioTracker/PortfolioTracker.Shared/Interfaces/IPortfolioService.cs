using PortfolioTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTracker.Interfaces
{
    public interface IPortfolioService
    {
        Task<InvestmentStatus> GetInvestmentReturnsValueAsync();

        Task<FundDistribution[]> GetFundDistributionAsync();

        Task<List<PortfolioSnapshot>> GetPortfolioSnapshotAsync();

        Task<bool> RemoveFundFromFolio(PortfolioSnapshot portfolioSnapshot);

        Task<bool> AddFundToPortfolioAsync(FundInfo fundInfo);

    }
}
