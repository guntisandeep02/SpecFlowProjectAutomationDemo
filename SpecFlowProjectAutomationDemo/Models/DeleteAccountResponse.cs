using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectAutomationDemo.Models
{
    internal class DeleteAccountResponse
    {
        [JsonProperty("data")]
        public object Data { get; set; } // Use 'object' type to handle different data structures

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public string[] Errors { get; set; }

        [JsonProperty("data1")]
        public object Data1 { get; set; }

        [JsonProperty("data2")]
        public object Data2 { get; set; }

        [JsonProperty("data3")]
        public object Data3 { get; set; }
    }
}
