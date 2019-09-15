using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

// todo mlh https://www.yr.no/place/United_States/Tennessee/Super_8_Memphis_Airport_E_Tn/forecast.xml

namespace Wally.Core {
    public class WeatherGetter {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly IconGetter _iconGetter;
        private readonly string _apiKey;
        public WeatherGetter(string apiKey, IconGetter iconGetter) {
            _apiKey = apiKey;
            _iconGetter = iconGetter;
        }

        public async Task<Weather> Get(WeatherCoordinate weatherCoordinate) {
            string content = null;
            var currentTemperature = -99m;
            var currentSummary = "Error";
            var dailyForecasts = new List<DailyForecast>();
            try {
                content = await HttpActor.GetResponseContent($"https://api.darksky.net/forecast/{_apiKey}/{weatherCoordinate.Latitude},{weatherCoordinate.Longitude}");
                var jObject = JObject.Parse(content);
                var currently = jObject.Value<JObject>("currently");
                currentTemperature = currently.Value<decimal>("temperature");
                currentSummary = currently.Value<string>("summary");
                var daily = jObject.Value<JObject>("daily");
                var forecasts = daily.Value<JArray>("data");
                foreach (var forecast in forecasts) {
                    var when = Epoch.AddSeconds(forecast.Value<long>("time"));
                    var maximumFahrenheitValue = forecast.Value<decimal>("temperatureHigh");
                    var minimumFahrenheitValue = forecast.Value<decimal>("temperatureLow");
                    var summary = forecast.Value<string>("summary");
                    var icon = forecast.Value<string>("icon");
                    var iconBase64 = _iconGetter.GetBase64(icon);
                    dailyForecasts.Add(new DailyForecast(when, maximumFahrenheitValue, minimumFahrenheitValue, summary, iconBase64));
                }
            }
            catch (Exception e) {
                Logger.Error($"Unable to get daily forecasts (content: '{content}')", e);
                dailyForecasts.Clear();
                for (var i = 0; i < 6; i++) {
                    dailyForecasts.Add(new DailyForecast(DateTime.MinValue, 99, -99, string.Empty, string.Empty));
                }
            }
            var currentConditions = new CurrentConditions(currentTemperature, currentSummary);
            var result = new Weather(currentConditions, dailyForecasts);
            return result;
        }
    }

    public class Weather {
        public Weather(CurrentConditions currentConditions, IReadOnlyCollection<DailyForecast> dailyForecasts) {
            CurrentConditions = currentConditions;
            DailyForecasts = dailyForecasts;
        }
        public CurrentConditions CurrentConditions { get; }
        public IReadOnlyCollection<DailyForecast> DailyForecasts { get; }
    }
}