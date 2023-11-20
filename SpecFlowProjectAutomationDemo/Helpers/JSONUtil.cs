using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectAutomationDemo.Helpers
{
    internal class JSONUtil
    {
        public async Task<string> getJSONString(HttpResponseMessage response , string jsonPath)
        {
            JObject jsonResponse = JObject.Parse(await response.Content.ReadAsStringAsync());
            string jsonData = (string)jsonResponse.SelectToken(jsonPath);
            return jsonData;
        }

        public async Task<int> GetJsonIntValue(HttpResponseMessage response, string jsonPath)
        {
            JObject jsonResponse = JObject.Parse(await response.Content.ReadAsStringAsync());

            JToken jsonToken = jsonResponse.SelectToken(jsonPath);

            if (jsonToken != null && jsonToken.Type == JTokenType.Integer)
            {
                return jsonToken.Value<int>();
            }
            else
            {
                throw new InvalidOperationException($"The value at '{jsonPath}' is not a valid integer.");
            }
        }


    }
}
