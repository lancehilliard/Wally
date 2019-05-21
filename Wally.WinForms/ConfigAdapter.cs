using System;
using System.Collections.Generic;
using System.Globalization;
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

        public IReadOnlyCollection<DaysUntilEvent> ToDaysUntilEvents(string config) {
            var result = new List<DaysUntilEvent>();
            var eventsData = config.Split(';');
            foreach (var eventData in eventsData)
            {
                var parts = eventData.Split('|');
                var name = parts[0];
                var when = parts[1];
                var displayCountInDays = Convert.ToInt32(parts[2]);
                if (when.Length == 4)
                {
                    when = $"{DateTime.Now.Year}{when}";
                }
                var moment = DateTime.ParseExact(when, "yyyyMMdd", CultureInfo.InvariantCulture);
                if (moment.Date < DateTime.Now.Date)
                {
                    moment = moment.AddYears(1);
                }
                var daysUntilEvent = new DaysUntilEvent(name, moment, displayCountInDays);
                result.Add(daysUntilEvent);
            }
            return result.OrderBy(x=>x.DaysUntil).ToList();
        }
    }
}