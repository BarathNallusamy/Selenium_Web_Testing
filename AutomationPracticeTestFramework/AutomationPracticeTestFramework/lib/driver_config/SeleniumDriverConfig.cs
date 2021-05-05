using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AutomationPracticeTestFramework
{
    public class SeleniumDriverConfig
    {
        public IWebDriver Driver { get; set; }

        public SeleniumDriverConfig(string driver, int pageLoadSecs, int waitSecs)
        {
            DriverSetUp(driver, pageLoadSecs, waitSecs);
        }

        public void DriverSetUp(string driver, int pageLoadSecs, int waitSecs)
        {
            if(driver.ToLower() == "chrome")
            {
                SetChromeDriver();
            }
            else if (driver.ToLower() == "firefox")
            {
                setFireFoxDriver();
            }
            else
            {
                throw new Exception("Please use 'chrome' or 'firefox' as the driver argument.");
            }
            SetDriverConfiguration(pageLoadSecs, waitSecs);
        }


        public void SetDriverConfiguration(int pageLoadSecs, int waitSecs)
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadSecs);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitSecs);
        }

        public void setFireFoxDriver()
        {
            Driver = new FirefoxDriver();
        }

        public void SetChromeDriver()
        {
            Driver = new ChromeDriver();
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("headless");//it will basically not show the opening and closing of the page during test
        }
    }
}
