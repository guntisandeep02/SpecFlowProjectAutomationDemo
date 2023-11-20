using Newtonsoft.Json;
using SpecFlowProjectAutomationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectAutomationDemo.Support
{
    internal class DepositAccountJson
    {
        public string getStringResponse()
        {
            string payload = @"{
            ""data"": null,
            ""message"": ""$2000 deposited to Account X123 successfully"",
            ""errors"": [],
            ""data1"": {
                ""accountNumber"": ""X123"",
                ""newBalance"": 2000
            }
        }";

            // Deserialize the payload
            DepositAccountResponse depositAccountResponse = JsonConvert.DeserializeObject<DepositAccountResponse>(value: payload);
         
            return depositAccountResponse.Message;
           
        }

        public int getIntResponse()
        {
            string payload = @"{
            ""data"": null,
            ""message"": ""$2000 deposited to Account X123 successfully"",
            ""errors"": [],
            ""data1"": {
                ""accountNumber"": ""X123"",
                ""newBalance"": 2000
            }
        }";

            // Deserialize the payload
            DepositAccountResponse depositAccountResponse = JsonConvert.DeserializeObject<DepositAccountResponse>(value: payload);
            
            return (int) depositAccountResponse.Data1.NewBalance;

        }
    }
}
