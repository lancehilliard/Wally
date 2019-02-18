using System;

namespace Wally.Tour {
    public class Page {
        public Page(string voiceCommandWord, string url, DateTime? expiration = null, int secondsToWaitForPageLoad = 0) {
            VoiceCommandWord = voiceCommandWord;
            Url = url;
            SecondsToWaitForPageLoad = secondsToWaitForPageLoad;
            Expiration = DateTime.MinValue.Equals(expiration) ? null : expiration;
        }

        public string VoiceCommandWord { get; }
        public string Url { get; }
        public int SecondsToWaitForPageLoad { get; }
        public DateTime? Expiration { get; }
        public bool IsExpired => DateTime.Now > (Expiration ?? DateTime.Now.AddMinutes(1));
    }
}