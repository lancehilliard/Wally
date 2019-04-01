using System;
using System.Net;

namespace Wally.Core {
    public class ShortTimeWebClient : WebClient {
        protected override WebRequest GetWebRequest(Uri uri) {
            var w = base.GetWebRequest(uri);
            if (w != null) {
                w.Timeout = (int) TimeSpan.FromSeconds(1).TotalMilliseconds;
            }
            return w;
        }
    }
}