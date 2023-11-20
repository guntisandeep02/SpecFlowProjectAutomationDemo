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
    public class WithdrawAmountFromTheAccountStepDefinitions
    {
        WithdrawAmountRequest withdrawAmountRequest = new WithdrawAmountRequest();
        string baseUrl = "https://localhost:7245/api/Account/withdraw";
        HttpResponseMessage response;
        string payload;

        [Given(@"Withdraw the amount (.*)")]
        public void GivenWithdrawTheAmount(int withdrawAmount)
        {
            withdrawAmountRequest.Amount = withdrawAmount;
        }

        [When(@"User sends the PUT request to withdraw amount")]
        public void WhenUserSendsThePUTRequestToWithdrawAmount()
        {
            HttpClient client = new HttpClient();
            payload = System.Text.Json.JsonSerializer.Serialize(withdrawAmountRequest);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, baseUrl)
            {
                Content = new StringContent(payload, Encoding.UTF8, "application/json")
            };

            response = client.Send(httpRequestMessage);
        }

        [Then(@"Verify the success response code and the success message for Withdraw Amount")]
        public async Task ThenVerifyTheSuccessResponseCodeAndTheSuccessMessageForWithdrawAmount()
        {
            Assert.True(response.IsSuccessStatusCode);

            JSONUtil jSONUtil = new JSONUtil();
            string successMessageActual = await jSONUtil.getJSONString(response, "$.message");
            
            WithdrawAmountJson withdrawAmountJson = new WithdrawAmountJson();
            string successMessageExpected = withdrawAmountJson.getStringResponse();
           
            Assert.AreEqual(successMessageActual, successMessageExpected);
            
        }
    }
}
