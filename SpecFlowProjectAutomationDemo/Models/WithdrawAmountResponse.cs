using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpecFlowProjectAutomationDemo.Models.CreateAccountResponse;

namespace SpecFlowProjectAutomationDemo.Models
{
    internal class WithdrawAmountResponse
    {
        [JsonProperty("data")]
        public object Data { get; set; } // Use 'object' type to handle the possibility of different data structures

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public string[] Errors { get; set; }

        [JsonProperty("data2")]
        public Data2 Data2 { get; set; }
    }
    public class Data2
    {
        [JsonProperty("accountID")]
        public string AccountID { get; set; }

        [JsonProperty("newBalance")]
        public decimal NewBalance { get; set; }
    }

}
