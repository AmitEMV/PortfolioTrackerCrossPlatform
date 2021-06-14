using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PortfolioTracker.Models
{
    public class ValueTrend
    {
        [JsonPropertyName("currentvalue")]
        public double CurrentValue { get; set; }

        [JsonPropertyName("investedvalue")]
        public double InvestedValue { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}
