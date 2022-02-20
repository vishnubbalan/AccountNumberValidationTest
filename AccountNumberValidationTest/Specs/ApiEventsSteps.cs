using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace AccountNumberValidationTest.Specs
{
    [Binding]
    public class ApiEventsSteps
    {
        string Endpoint = null;
        string AccNumber = null;
        string XAuthKey = null;
        string isTrue = null;
        ApiResponce apiResponce;

        [Given(@"I have API URL (.*)")]
        public void GivenIHaveAPIURL(string url)
        {
            Endpoint = url;
        }

        [Given(@"the XAuthKey is (.*)")]
        public void GivenTheXAuthKeyIs(string key)
        {
            XAuthKey = key;
        }

        [When(@"I verify the AccountNumber (.*)")]
        public void WhenIVerifyTheAccountNumber(string AccNumber)
        {
            ApiHelper helper = new ApiHelper();
            apiResponce = helper.CreateRequest(AccNumber, Endpoint, XAuthKey);
        }

        [Then(@"isValid in Responce is (.*)")]
        public void ThenIsValidInResponceIs(string isTrue)
        {
            if (apiResponce != null)
                Assert.IsTrue(apiResponce.isValid.ToString().Equals(isTrue), "Mismatch in isValid responce");
            else
                Assert.Fail("Exception occured in responce");
        }

        [Then(@"Responce StatusCode is (.*)")]
        public void ThenResponceStatusCodeIs(int code)
        {
            Assert.IsTrue(apiResponce.statusCode.Equals(code), "Mismatch in responce Status code");
        }

    }
}
