using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationPracticeTestFramework.BDD
{
    [Binding]
    public class AP_ForgotPasswordSteps
    {
        private AP_Website _website = new AP_Website("chrome");

        [When(@"I click the forgot password link")]
        public void WhenIClickTheForgotPasswordLink()
        {
            _website.AP_SignInPage.VisitSignInPage();
            _website.AP_SignInPage.ClickForgotPassword();
        }
        
        [Then(@"I should be able to navigate to the Forgot password page")]
        public void ThenIShouldBeAbleToNavigateToTheForgotPasswordPage()
        {
            Assert.That(_website.getPageTitle(), Is.EqualTo("Forgot your password - My Store"));
        }
    }
}
