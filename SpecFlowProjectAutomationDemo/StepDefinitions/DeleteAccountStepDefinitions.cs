using NUnit.Framework;
using SpecFlowProjectAutomationDemo.Helpers;
using SpecFlowProjectAutomationDemo.Models;
using SpecFlowProjectAutomationDemo.ResponseJSONPayload;
using SpecFlowProjectAutomationDemo.Support;
using System;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProjectAutomationDemo.StepDefinitions
{
    [Binding]
    public class DeleteAccountStepDefinitions
    {
        public HttpClient httpClient;
        string baseUrl; 
        HttpResponseMessage response;
       
        [Given(@"The endpoint for account deletion")]
        public void GivenTheEndpointForAccountDeletion()
        {
           baseUrl = "https://localhost:7245/api/Account/delete/X123";
        }

        [When(@"User sends the DELETE request to delete account")]
        public void WhenUserSendsTheDELETERequestToDeleteAccount()
        {
            HttpClient client = new HttpClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, baseUrl);

            response = client.Send(httpRequestMessage);
        }

        [Then(@"the account with ID should be deleted successfully")]
        public async Task ThenTheAccountWithIDShouldBeDeletedSuccessfully()
        {
            Assert.True(response.IsSuccessStatusCode);

            JSONUtil jSONUtil = new JSONUtil();
            string successMessageActual = await jSONUtil.getJSONString(response, "$.message");

            DeleteAccountJson deleteAccount = new DeleteAccountJson();
            string successMessageExpected = deleteAccount.getStringResponse();

            Assert.AreEqual(successMessageActual, successMessageExpected);
        }

    }
}
