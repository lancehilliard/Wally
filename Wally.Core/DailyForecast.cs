using System;

namespace Wally.Core {
    public class DailyForecast {
        public DailyForecast(DateTime when, decimal maximumFahrenheitTemperature, decimal minimumFahrenheitTemperature, string summary, string iconBase64) {
            When = when;
            MaximumFahrenheitTemperature = maximumFahrenheitTemperature;
            MinimumFahrenheitTemperature = minimumFahrenheitTemperature;
            IconBase64 = iconBase64;
            Summary = summary;
        }
        public DateTime When { get; }
        public decimal MaximumFahrenheitTemperature { get; set; }
        public decimal MinimumFahrenheitTemperature { get; set; }
        public string IconBase64 { get; }
        public string Summary { get; }
    }
}