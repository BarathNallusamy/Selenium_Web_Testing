using NUnit.Framework;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace AutomationPracticeTestFramework.BDD
{
    [Binding]
    public class AP_NavigationSteps
    {
        private AP_Website _website = new AP_Website("chrome");

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            _website.AP_HomePage.visitHomePage();
        }
        
        [When(@"I click the sign in link")]
        public void WhenIClickTheSignInLink()
        {
            _website.AP_HomePage.clickSignInLink();
            
        }
        
        [Then(@"I should be able to navigate to the sign in page")]
        public void ThenIShouldBeAbleToNavigateToTheSignInPage()
        {
            Assert.That(_website.getPageTitle(), Is.EqualTo("Login - My Store"));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.SeleniumDriver.Quit();
            _website.SeleniumDriver.Dispose();
        }
    }
}
