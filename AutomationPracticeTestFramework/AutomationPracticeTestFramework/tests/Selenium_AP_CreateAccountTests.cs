using System;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Threading;

namespace AutomationPracticeTestFramework
{
    public class Selenium_AP_CreateAccountTests
    {
        AP_Website AP_Website { get; } = new AP_Website("chrome");

        [Test]
        public void GivenIAmOnTheSignInPage_WhenIClickTheCreateAccountWithAnExistingEmail_ThenIReceiveAnErrorMessage()
        {
            AP_Website.AP_SignInPage.VisitSignInPage();
            AP_Website.AP_SignInPage.InputNewEmail("testing@gmail.com");
            AP_Website.AP_SignInPage.ClickCreateAccountBtn();
            Thread.Sleep(5000);
            Assert.That(AP_Website.AP_SignInPage.GetCreateAccountAlertMessage(), Does.Contain("email address has already been registered"));
        }

        [OneTimeTearDown]
        public void tearDown()
        {
            //quits the sriver, closing all the associated windows
            AP_Website.SeleniumDriver.Quit();
            //release resources
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}
