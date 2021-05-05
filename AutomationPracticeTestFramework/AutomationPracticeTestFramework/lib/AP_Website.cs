using System;
using OpenQA.Selenium;

namespace AutomationPracticeTestFramework
{
    public class AP_Website
    {
        public IWebDriver SeleniumDriver { get; internal set; }
        public AP_HomePage AP_HomePage { get; internal set; }
        public AP_SignInPage AP_SignInPage { get; internal set; }
        public AP_ForgotPasswordPage AP_ForgotPasswordPage { get;internal set; }

        public AP_Website(string driver, int pageLoadSecs=10, int waitSecs=10)
        {
            //construct and configure the driver
            SeleniumDriver = new SeleniumDriverConfig(driver, pageLoadSecs, waitSecs).Driver;
            SeleniumDriver.Manage().Window.Maximize();

            //construct the page objects with a reference to the driver
            AP_HomePage = new AP_HomePage(SeleniumDriver);
            AP_SignInPage = new AP_SignInPage(SeleniumDriver);
            AP_ForgotPasswordPage = new AP_ForgotPasswordPage(SeleniumDriver);
        }

        //delete cookies (optional)
        public void DeleteCookies()
        {
            SeleniumDriver.Manage().Cookies.DeleteAllCookies();
        }

        public string getPageTitle()
        {
            return SeleniumDriver.Title;
        }


    }
}
