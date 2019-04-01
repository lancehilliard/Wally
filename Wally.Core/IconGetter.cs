using System;
using System.Collections.Generic;

namespace Wally.Core {
    // https://www.deviantart.com/merlinthered/art/plain-weather-icons-157162192
    public class IconGetter {
        static readonly Dictionary<string, byte[]> IconBytes = new Dictionary<string, byte[]> {
            {"clear-day", Icons.clear_day},
            {"clear-night", Icons.clear_night},
            {"rain", Icons.rain},
            {"snow", Icons.snow},
            {"sleet", Icons.sleet},
            {"wind", Icons.wind},
            {"fog", Icons.fog},
            {"cloudy", Icons.cloudy},
            {"partly-cloudy-day", Icons.partly_cloudy_day},
            {"partly-cloudy-night", Icons.clear_day}, // https://darksky.net/dev/docs/faq#icon-selection
        };

        public string GetBase64(string iconKey) {
            string result = null;
            if (IconBytes.ContainsKey(iconKey)) {
                var bytes = IconBytes[iconKey];
                result = Convert.ToBase64String(bytes);
            }
            return result;
        }
    }
}