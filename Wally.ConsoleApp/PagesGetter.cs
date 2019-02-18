using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Wally.Tour;

namespace Wally.ConsoleApp {
    public class PagesGetter {
        public IReadOnlyCollection<Page> Get() {
            var pagesJson = File.ReadAllText("pages.json");
            var pagesArray = JArray.Parse(pagesJson);
            var result = pagesArray.Children().Select(x => {
                var voiceCommandWord = x["VoiceCommandWord"].Value<string>();
                var url = x["Url"].Value<string>();
                DateTime.TryParse(x["Expiration"]?.Value<string>(), out var expiration);
                int.TryParse(x["SecondsToDisplayAfterAction"]?.Value<string>(), out var secondsToDisplayAfterAction);
                int.TryParse(x["SecondsToWaitForPageLoad"]?.Value<string>(), out var secondsToWaitForPageLoad);
                return new Page(voiceCommandWord, url, expiration: expiration, secondsToDisplayAfterAction: secondsToDisplayAfterAction, secondsToWaitForPageLoad: secondsToWaitForPageLoad);
            }).ToList();
            return result;
        }
    }
}