using System;
using OpenQA.Selenium;

namespace Wally.Tour {
    public class Page {
        private const int DefaultDisplayDurationInSeconds = 180;

        public Page(string voiceCommandWord, string url, Func<IWebDriver, Action> driverAction = null, int? secondsToDisplayAfterAction = null, DateTime? expiration = null, int secondsToWaitForPageLoad = 0) {
            VoiceCommandWord = voiceCommandWord;
            Url = url;
            DriverAction = driverAction;
            SecondsToWaitForPageLoad = secondsToWaitForPageLoad;
            Expiration = DateTime.MinValue.Equals(expiration) ? null : expiration;
            SecondsToDisplayAfterAction = secondsToDisplayAfterAction ?? DefaultDisplayDurationInSeconds;

        }

        public int SecondsToDisplayAfterAction { get; }
        public string VoiceCommandWord { get; }
        public string Url { get; }
        public Func<IWebDriver, Action> DriverAction { get; }
        public int SecondsToWaitForPageLoad { get; }
        public DateTime? Expiration { get; }
        public bool IsExpired => DateTime.Now > (Expiration ?? DateTime.Now.AddMinutes(1));
    }
}