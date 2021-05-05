using OpenQA.Selenium;

namespace AutomationPracticeTestFramework
{
    public class AP_SignInPage
    {
        public IWebDriver SeleniumDriver { get; }
        private string SignInPage = AppConfigReader.SignInPageUrl;

        private IWebElement _emailFeild => SeleniumDriver.FindElement(By.Id("email"));
        private IWebElement _passwordFeild => SeleniumDriver.FindElement(By.Id("passwd"));
        private IWebElement _alertMessage => SeleniumDriver.FindElement(By.ClassName("alert"));
        private IWebElement _forgotPassword => SeleniumDriver.FindElement(By.LinkText("Forgot your password?"));
        private IWebElement _submitBtn => SeleniumDriver.FindElement(By.Id("SubmitLogin"));
        private IWebElement _subscribeEmail => SeleniumDriver.FindElement(By.Id("email_create"));
        private IWebElement _createSubmitBtn => SeleniumDriver.FindElement(By.Id("SubmitCreate"));
        private IWebElement _createAccAlertMessage => SeleniumDriver.FindElement(By.Id("create_account_error"));

        public AP_SignInPage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitSignInPage()
        {
            SeleniumDriver.Navigate().GoToUrl(SignInPage);
        }

        public void InputEmailId(string email)
        {
            _emailFeild.SendKeys(email);
        }

        public void InputPassword(string password)
        {
            _passwordFeild.SendKeys(password);
        }

        public string GetAlertMessage()
        {
            return _alertMessage.Text;
        }

        public string GetCreateAccountAlertMessage()
        {
            return _createAccAlertMessage.Text;
        }

        public void ClickForgotPassword()
        {
            _forgotPassword.Click();
        }

        public void ClickSubmitBtn()
        {
            _submitBtn.Click();
        }

        public void InputNewEmail(string email)
        {
            _subscribeEmail.SendKeys(email);
        }

        public void ClickCreateAccountBtn()
        {
            _createSubmitBtn.Click();
        }
    }
}