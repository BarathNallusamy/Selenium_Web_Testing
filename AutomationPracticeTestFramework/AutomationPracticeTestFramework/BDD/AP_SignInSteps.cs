using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationPracticeTestFramework.BDD
{
    [Binding]
    public class AP_SignInSteps
    {
        private AP_Website _website = new AP_Website("chrome");
        
        [Given(@"I am on the sign in page")]
        public void GivenIAmOnTheSignInPage()
        {
            _website.AP_SignInPage.VisitSignInPage();
        }
        
        [Given(@"I have entered the email ""(.*)""")]
        public void GivenIHaveEnteredTheEmail(string email)
        {
            _website.AP_SignInPage.InputEmailId(email);
        }
        
        [Given(@"I have entered the password (.*)")]
        public void GivenIHaveEnteredThePassword(string password)
        {
            _website.AP_SignInPage.InputPassword(password);
        }
        
        [When(@"I click the sign in button")]
        public void WhenIClickTheSignInButton()
        {
            _website.AP_SignInPage.ClickSubmitBtn();
        }
        
        [Then(@"I should see an alert containing the error message ""(.*)""")]
        public void ThenIShouldSeeAnAlertContainingTheErrorMessage(string expectedMessage)
        {
            Assert.That(_website.AP_SignInPage.GetAlertMessage(), Does.Contain(expectedMessage));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.SeleniumDriver.Quit();
            _website.SeleniumDriver.Dispose();
        }
    }
}
