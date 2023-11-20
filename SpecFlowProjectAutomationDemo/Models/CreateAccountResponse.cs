using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectAutomationDemo.Models
{
    internal class CreateAccountResponse
    {
        [JsonProperty("data")]
        public Data data { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("errors")]
        public object[] errors { get; set; }
     

        public class Data
        {
            [JsonProperty("newBalance")]
            public int newBalance { get; set; }
            [JsonProperty("accountName")]
            public string accountName { get; set; }
            [JsonProperty("accountNumber")]
            public string accountNumber { get; set; }
        }

    }
}
