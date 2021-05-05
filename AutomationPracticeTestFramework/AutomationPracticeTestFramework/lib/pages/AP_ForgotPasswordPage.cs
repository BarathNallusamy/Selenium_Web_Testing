using OpenQA.Selenium;

namespace AutomationPracticeTestFramework
{
    public class AP_ForgotPasswordPage
    {
        public IWebDriver SeleniumDriver { get; }
        private string SignInPage = AppConfigReader.ForgotPasswordUrl;

        

        public AP_ForgotPasswordPage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

    }
}
