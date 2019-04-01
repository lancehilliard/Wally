using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Wally.Core {
    public static class HttpActor {
        private static readonly HttpClient H = new HttpClient();
        public static async Task<string> GetResponseContent(string requestUri) {
            string result;
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), requestUri)) {
                var response = await H.SendAsync(request);
                var responseStream = await response.Content.ReadAsStreamAsync();
                var streamReader = new StreamReader(responseStream);
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}