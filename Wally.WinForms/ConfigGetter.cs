using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using Wally.Core;

namespace Wally.WinForms {
    public class ConfigGetter {
        private static readonly string DaysUntilEventsAnnual = ConfigurationManager.AppSettings["DaysUntilEventsAnnual"];
        private static readonly string DaysUntilEventsOnce = ConfigurationManager.AppSettings["DaysUntilEventsAnnual"];
        private static readonly string WeatherCoordinate = ConfigurationManager.AppSettings["WeatherCoordinate"];
        private static readonly string BudgetCategories = ConfigurationManager.AppSettings["BudgetCategories"];
        public IReadOnlyCollection<BudgetApiCategory> GetBudgetApiCategories() {
            var delimitedCategories = BudgetCategories.Split('|');
            var result = delimitedCategories.Select(x => {
                var parts = x.Split(',');
                var displayName = parts[0];
                var budgetId = parts[1];
                var categoryId = parts[2];
                var extraDollars = Convert.ToDecimal(parts[3]);
                return new BudgetApiCategory(displayName, budgetId, categoryId, extraDollars);
            }).ToList();
            return result;
        }

        public WeatherCoordinate GetWeatherCoordinate() {
            var parts = WeatherCoordinate.Split(',');
            var latitude = double.Parse(parts[0].Trim());
            var longitude = double.Parse(parts[1].Trim());
            var result = new WeatherCoordinate(latitude, longitude);
            return result;
        }

        public IReadOnlyCollection<DaysUntilEvent> GetDaysUntilEvents() {
            var result = new List<DaysUntilEvent>();
            var eventsData = $"{DaysUntilEventsAnnual};{DaysUntilEventsOnce}".Split(';');
            foreach (var eventData in eventsData)
            {
                var parts = eventData.Split('|');
                var name = parts[0];
                var when = parts[1];
                var displayCountInDays = Convert.ToInt32(parts[2]);
                if (parts[1].Length == 4)
                {
                    when = $"{DateTime.Now.Year}{when}";
                }
                var moment = DateTime.ParseExact(when, "yyyyMMdd", CultureInfo.InvariantCulture);
                if (parts[1].Length == 4 && moment.Date < DateTime.Now.Date)
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