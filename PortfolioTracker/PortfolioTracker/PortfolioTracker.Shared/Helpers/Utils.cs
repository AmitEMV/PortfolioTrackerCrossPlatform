using PortfolioTracker.Models;
using System;
using System.Linq;
using System.Net.Http;

namespace PortfolioTracker.Helpers
{
    public static class Utils
    {
        private static readonly HttpClient httpClient;

        static Utils()
        {
            httpClient = new HttpClient();
        }

        public static FundDistribution[] GetFundDistributionPercentage(FundDistribution[] values)
        {
            FundDistribution[] fundDistributionsinPercent = new FundDistribution[values.Length];

            double totalValue = values.Sum(val => val.FundValue);

            fundDistributionsinPercent = values.Select(value =>
            {
                return new FundDistribution()
                {
                    FundType = value.FundType,
                    FundValue = Math.Round(value.FundValue / totalValue * 100)
                };
            }).ToArray();

            return fundDistributionsinPercent;
        }

        public static HttpClient GetHttpClient =>  httpClient;
    }
}
