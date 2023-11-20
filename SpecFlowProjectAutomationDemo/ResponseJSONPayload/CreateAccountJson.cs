using Newtonsoft.Json;
using SpecFlowProjectAutomationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectAutomationDemo.Support
{
    internal class CreateAccountJson
    {
       public string getResponse()
        {
            string payload = @"{
            ""data"": {
                ""newBalance"": 1000,
                ""accountName"": ""Sandeep Gunti"",
                ""accountNumber"": ""X123""
            },
            ""message"": ""Account X123 created successfully"",
            ""errors"": []
        }";
            CreateAccountResponse createAccountResponse = JsonConvert.DeserializeObject<CreateAccountResponse>(value: payload);

            // Access the deserialized data
            return createAccountResponse.message;
        }
    }
}
