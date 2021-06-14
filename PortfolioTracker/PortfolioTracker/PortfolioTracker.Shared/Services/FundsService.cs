using PortfolioTracker.Interfaces;
using PortfolioTracker.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static PortfolioTracker.Helpers.Utils;

namespace PortfolioTracker.Services
{
    public class FundsService : IFundsService
    {
        private readonly string apiURL;

        public FundsService(string URL)
        {
            apiURL = URL;
        }

        public async Task<List<FundPerformance>> GetFundPerformanceAsync(string API)
        {
            try
            {
                var response = await GetHttpClient.GetAsync(new Uri($"{apiURL}/api/home/{API}"));
                var content = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true
                };
                var result = JsonSerializer.Deserialize<List<FundPerformance>>(content, options);
                return result;
            }
            catch (Exception ex)
            {
            }

            return null;
        }

        public async Task<List<Funds>> GetFundsListAsync()
        {
            try
            {
                var response = await GetHttpClient.GetAsync(new Uri($"{apiURL}/api/home/funds"));
                var content = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true
                };
                var result = JsonSerializer.Deserialize<List<Funds>>(content, options);
                return result;
            }
            catch (Exception ex)
            {
            }

            return null;
        }

        public async Task<double> GetTotalValueAsync()
        {
            double totalValue;

            try
            {
                var response = await GetHttpClient.GetAsync(new Uri($"{apiURL}/api/home/totalvalue"));
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    totalValue = double.Parse(responseString);
                }
                else
                {
                    string res = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(res);
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return totalValue;
        }

        public Task<ValueTrend[]> GetTotalValueTrendAsync()
        {
            return null;
        }
    }
}
