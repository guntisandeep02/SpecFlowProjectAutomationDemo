using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlowProjectAutomationDemo.Helpers;
using SpecFlowProjectAutomationDemo.Models;
using SpecFlowProjectAutomationDemo.Support;
using System;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProjectAutomationDemo.StepDefinitions
{
    [Binding]
    public class DepositAccountStepDefinitions
    {
        DepositAccountRequest depositAccountRequest = new DepositAccountRequest();
        string baseUrl = "https://localhost:7245/api/Account/deposit";
        HttpResponseMessage response;
        string payload;

        [Given(@"The account Number details with ""([^""]*)""")]
        public void GivenTheAccountNumberDetailsWith(string accountNumber)
        {
            depositAccountRequest.accountNumber = accountNumber;
        }

        [Given(@"The amount (.*)")]
        public void GivenTheAmount(int updateddepositAmount)
        {
            depositAccountRequest.amount = updateddepositAmount;
        }

        [When(@"User sends the PUT request to deposit account")]
        public void WhenUserSendsThePUTRequestToDepositAccount()
        {
            HttpClient client = new HttpClient();
            payload = System.Text.Json.JsonSerializer.Serialize(depositAccountRequest);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, baseUrl)
            {
                Content = new StringContent(payload, Encoding.UTF8, "application/json")
            };

            response = client.Send(httpRequestMessage);
        }

        [Then(@"Verify the success response code and the success message for Deposit Account")]
        public async Task ThenVerifyTheSuccessResponseCodeAndTheSuccessMessageForDepositAccount()
        {
            Assert.True(response.IsSuccessStatusCode);
          
            JSONUtil jSONUtil = new JSONUtil();
            string successMessageActual = await jSONUtil.getJSONString(response, "$.message");
            int newBalanceAmount = await jSONUtil.GetJsonIntValue(response, "data1.newBalance");

            DepositAccountJson depositAccountJson = new DepositAccountJson();
            string successMessageExpected = depositAccountJson.getStringResponse();
            int updatedDepositAmountValueExpected = depositAccountJson.getIntResponse();

            Assert.AreEqual(successMessageActual, successMessageExpected);
            Assert.AreEqual(newBalanceAmount, updatedDepositAmountValueExpected);
        }
    }
}
