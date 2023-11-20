using Newtonsoft.Json;
using SpecFlowProjectAutomationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectAutomationDemo.Support
{
    internal class WithdrawAmountJson
    {
        public string getStringResponse()
        {
            string payload = @"{
            ""data"": null,
            ""message"": ""0 withdrawn from Account X123 successfully"",
            ""errors"": [],
            ""data1"": null,
            ""data2"": {
                ""accountID"": ""X123"",
                ""newBalance"": 0
            }
        }";

            // Deserialize the payload
            WithdrawAmountResponse withDrawResponse = JsonConvert.DeserializeObject<WithdrawAmountResponse>(payload);

            return withDrawResponse.Message;
        }
    }
}
