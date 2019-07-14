using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Wally.Core
{
    public class DataQuotaInfoGetter
    {
        public async Task<DataQuotaInfo> GetCurrentMonth(string username, string password) {
            decimal allowableUsage;
            decimal totalUsage;
            string unitOfMeasure;
            string monthName;
            string responseContent = null;
            try {
                using (var httpClient = new HttpClient()) {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://login.xfinity.com/login")) {
                        var data = new Dictionary<string, string> {
                            {"user", username}
                            , {"passwd", password}
                            , {"s", "oauth"}
                            , {"continue", "https://oauth.xfinity.com/oauth/authorize?client_id=my-account-web&prompt=login&redirect_uri=https%3A%2F%2Fcustomer.xfinity.com%2Foauth%2Fcallback&response_type=code"}
                        };
                        var content = string.Join("&", data.Select(x=>$"{x.Key}={WebUtility.UrlEncode(x.Value)}"));
                        request.Content = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");
                        var response = await httpClient.SendAsync(request);
                        var responseStream = await response.Content.ReadAsStreamAsync();
                        var streamReader = new StreamReader (responseStream);
                        streamReader.ReadToEnd();
                    }
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://customer.xfinity.com/apis/services/internet/usage"))
                    {
                        var response = await httpClient.SendAsync(request);
                        var responseStream = await response.Content.ReadAsStreamAsync();
                        var streamReader = new StreamReader (responseStream);
                        responseContent = streamReader.ReadToEnd();
                        var parsedResponse = JObject.Parse(responseContent);
                        var usageMonths = parsedResponse["usageMonths"];
                        var currentMonthUsage = usageMonths.Last;
                        allowableUsage = currentMonthUsage.Value<decimal?>("allowableUsage") ?? 0;
                        totalUsage = currentMonthUsage.Value<decimal?>("totalUsage") ?? 0;
                        unitOfMeasure = currentMonthUsage.Value<string>("unitOfMeasure") ?? "??";
                        monthName = currentMonthUsage.Value<DateTime>("startDate").ToString("MMM");
                    }
                }
            }
            catch (Exception e) {
                Logger.Error($"Unable to get quota info (content: {responseContent})", e);
                allowableUsage = 0;
                totalUsage = 0;
                unitOfMeasure = "???";
                monthName = "Error";
            }
            var result = new DataQuotaInfo(allowableUsage, totalUsage, unitOfMeasure, monthName);
            return result;
        }
    }
}
