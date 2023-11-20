using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpecFlowProjectAutomationDemo.Models.CreateAccountResponse;

namespace SpecFlowProjectAutomationDemo.Models
{
    internal class DepositAccountResponse
    {

        [JsonProperty("data")]
        public object Data { get; set; } // Use 'object' type to handle the possibility of null or another data structure

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public string[] Errors { get; set; }

        [JsonProperty("data1")]
        public Data1 Data1 { get; set; }
    }

    public class Data1
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("newBalance")]
        public decimal NewBalance { get; set; }
    }
}
