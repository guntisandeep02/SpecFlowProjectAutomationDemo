using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlowProjectAutomationDemo.Helpers;
using SpecFlowProjectAutomationDemo.Models;
using SpecFlowProjectAutomationDemo.Support;
using System;
using System.Text;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace SpecFlowProjectAutomationDemo.StepDefinitions
{
    [Binding]
    public class CreateNewAccountStepDefinitions
    {
        AccountInformationRequest accountInformationRequest = new AccountInformationRequest();
        string baseUrl = "https://localhost:7245/api/Account/create";
        HttpResponseMessage response;
        string payload;

        [Given(@"The account initial amount (.*)")]
        public void GivenTheAccountInitialAmount(int amount)
        {
            accountInformationRequest.InitialBalance = amount;
        }

        [Given(@"The Account Name is ""([^""]*)""")]
        public void GivenTheAccountNameIs(string accountName)
        {
            accountInformationRequest.AccountName = accountName;

        }

        [Given(@"The address is ""([^""]*)""")]
        public void GivenTheAddressIs(string address)
        {
            accountInformationRequest.Address = address;
        }

        [When(@"User sends the POST request to create new account")]
        public void WhenUserSendsThePOSTRequestToCreateNewAccount()
        {
            HttpClient client = new HttpClient();
            payload = System.Text.Json.JsonSerializer.Serialize(accountInformationRequest);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, baseUrl)
            {
                Content = new StringContent(payload, Encoding.UTF8, "application/json")
            };

            response = client.Send(httpRequestMessage);

        }

        [Then(@"Verify the success response code and the success message")]
        public async Task ThenVerifyTheSuccessResponseCodeAndTheSuccessMessageAsync()
        {
            Assert.True(response.IsSuccessStatusCode);
            
            JSONUtil jSONUtil  = new JSONUtil();
            string successMessageActual = await jSONUtil.getJSONString(response,"$.message");
            CreateAccountJson createAccountJson = new CreateAccountJson();
            string successMessageExpected = createAccountJson.getResponse();

            Assert.AreEqual(successMessageActual, successMessageExpected);  





        }
    }
}
