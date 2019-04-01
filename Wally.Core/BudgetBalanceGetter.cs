using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Wally.Core {
    public class BudgetBalanceGetter {
        private static readonly HttpClient HttpClient = new HttpClient();
        private readonly string _apiKey;
        public BudgetBalanceGetter(string apiKey) {
            _apiKey = apiKey;
        }

        public async Task<decimal> Get(string budgetId, string categoryId) {
            decimal result = -999;
            string content = null;
            try {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
                content = await HttpClient.GetStringAsync($"https://api.youneedabudget.com/v1/budgets/{budgetId}/categories/{categoryId}");
                var jObject = JObject.Parse(content);
                var data = jObject["data"];
                var category = data["category"];
                var balanceMilliUnits = category.Value<decimal>("balance");
                result = Math.Round(balanceMilliUnits / 1000, 2);
            }
            catch (Exception e) {
                Logger.Error($"Unable to get balance (content: {content})", e);
            }
            return result;
        }
    }
}