using System.Collections.Generic;
using System.Linq;
using Wally.Core;

namespace Wally.WinForms {
    public class ConfigAdapter {
        public IReadOnlyCollection<BudgetApiCategory> ToBudgetApiCategories(string config) {
            var delimitedCategories = config.Split('|');
            var result = delimitedCategories.Select(x => {
                var parts = x.Split(',');
                var displayName = parts[0];
                var budgetId = parts[1];
                var categoryId = parts[2];
                return new BudgetApiCategory(displayName, budgetId, categoryId);
            }).ToList();
            return result;
        }

        public WeatherCoordinate ToWeatherCoordinate(string weatherCoordinate) {
            var parts = weatherCoordinate.Split(',');
            var latitude = double.Parse(parts[0].Trim());
            var longitude = double.Parse(parts[1].Trim());
            var result = new WeatherCoordinate(latitude, longitude);
            return result;
        }
    }
}