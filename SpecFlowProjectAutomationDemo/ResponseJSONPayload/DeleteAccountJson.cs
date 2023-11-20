using Newtonsoft.Json;
using SpecFlowProjectAutomationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectAutomationDemo.ResponseJSONPayload
{
    internal class DeleteAccountJson
    {
        public string getStringResponse()
        {
            string payload = @"{
            ""data"": null,
            ""message"": ""Account X123 deleted successfully"",
            ""errors"": [],
            ""data1"": null,
            ""data2"": null,
            ""data3"": null
        }";

            // Deserialize the payload
            DeleteAccountResponse deleteAccontResponse = JsonConvert.DeserializeObject<DeleteAccountResponse>(payload);
            return deleteAccontResponse.Message;
        }
    }
}
