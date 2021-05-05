using System;
using NUnit.Framework;
using System.Threading;

namespace AutomationPracticeTestFramework
{
    public class Selenium_AP_SignInTests
    {
        //create an AP website instance
        public AP_Website AP_Website { get; } = new AP_Website("chrome");
        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickTheSignInLink_ThenIGoToTheSignInPage()
        {
            AP_Website.AP_HomePage.visitHomePage();
            AP_Website.AP_HomePage.clickSignInLink();
            Assert.That(AP_Website.getPageTitle(), Is.EqualTo("Login - My Store"));
        }


        [Test]
        public void GivenIAmOnTheSignInPage_AnIEnterA4DigitPassword_WhenICLickTheSignInButton_ThenIGetAnErrorMessage()
        {
            AP_Website.AP_SignInPage.VisitSignInPage();
            AP_Website.AP_SignInPage.InputEmailId("testing@gmail.com");
            AP_Website.AP_SignInPage.InputPassword("four");
            AP_Website.AP_SignInPage.ClickSubmitBtn();

            Assert.That(AP_Website.AP_SignInPage.GetAlertMessage(), Does.Contain("Invalid password"));
        }

        ////Above code before refactoring
        //[Test]
        //public void GivenIAmOnTheSignInPage_AnIEnterA4DigitPassword_WhenICLickTheSignInButton_ThenIGetAnErrorMessage()
        //{
        //    using (IWebDriver driver = new ChromeDriver())
        //    {
        //        //Arrange
        //        driver.Manage().Window.Maximize();

        //        //navigate through the sign in page
        //        driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");

        //        //find the email and password text feilds and get a reference to those feilds
        //        IWebElement emailFeilds = driver.FindElement(By.Id("email"));
        //        emailFeilds.SendKeys("testing@snailmail.com");
        //        IWebElement passwordFeild = driver.FindElement(By.Id("passwd"));
        //        passwordFeild.SendKeys("four");
        //        //get a reference to the sign in button
        //        IWebElement signInButton = driver.FindElement(By.Id("SubmitLogin"));

        //        //Act - click the login button
        //        signInButton.Click();

        //        //Assert
        //        //get a reference to the alert element
        //        IWebElement alert = driver.FindElement(By.ClassName("alert"));
        //        //check the error message is correct
        //        Assert.That(alert.Text.Contains("Invalid password"));
        //    }
        //}

        [Test]
        public void GivenIAmOnTheSignInPage_WhenILeaveTheEmailFieldEmpty_ThenIReceiveAnErrorMessage()
        {
            AP_Website.AP_SignInPage.VisitSignInPage();
            AP_Website.AP_SignInPage.InputEmailId(" ");
            AP_Website.AP_SignInPage.InputPassword("12345623");
            AP_Website.AP_SignInPage.ClickSubmitBtn();

            Assert.That(AP_Website.AP_SignInPage.GetAlertMessage(), Does.Contain("An email address required."));
        }

        //Above code before refactoring
        //[Test]
        //public void GivenIAmOntheSignInPage_WhenIFailedToProvideAnEmailAddress_ThenIReceiveAnErrorMessage()
        //{
        //    using (IWebDriver driver = new ChromeDriver())
        //    {
        //        //Arrange
        //        driver.Manage().Window.Maximize();

        //        //navigate through the sign in page
        //        driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");

        //        IWebElement emailFeilds = driver.FindElement(By.Id("email"));
        //        emailFeilds.SendKeys(" ");
        //        IWebElement passwordFeild = driver.FindElement(By.Id("passwd"));
        //        passwordFeild.SendKeys("four");
        //        //get a reference to the sign in button
        //        IWebElement signInButton = driver.FindElement(By.Id("SubmitLogin"));

        //        signInButton.Click();

        //        //Assert
        //        IWebElement errorMessage = driver.FindElement(By.ClassName("alert"));
        //        Assert.That(errorMessage.Text.Contains("An email address required."));
        //    }

        //}

        [Test]
        public void GivenIAmOnTheHSignInPage_WhenIClickTheForgotPassword_ThenIGoToTheForgotPasswordPage()
        {
            AP_Website.AP_SignInPage.VisitSignInPage();
            AP_Website.AP_SignInPage.ClickForgotPassword();
            Assert.That(AP_Website.getPageTitle(), Is.EqualTo("Forgot your password - My Store"));
        }

        [Test]
        public void GivenIAmOnTheSignInPage_WhenISelectIForgotThePassWord_ThenThePageShouldNavigateToForgottenPasswordPage()
        {
            AP_Website.AP_SignInPage.VisitSignInPage();
            AP_Website.AP_SignInPage.InputEmailId("testing@gmail.com");
            AP_Website.AP_SignInPage.ClickForgotPassword();

            Assert.That(AP_Website.getPageTitle(), Is.EqualTo("Forgot your password - My Store"));
        }

        ////Above test is made from below shown test before refactoring
        //[Test]
        //public void GivenIAmOnTheSignInPage_WhenISelectIForgotThePassWord_ThenThePageShouldNavigateToForgottenPasswordPage()
        //{
        //    using (IWebDriver driver = new ChromeDriver())
        //    {
        //        driver.Manage().Window.Maximize();
        //        driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");



        //        IWebElement forgottenPassword = driver.FindElement(By.ClassName("lost_password"));
        //        forgottenPassword.Click();

        //        Thread.Sleep(5000);
        //        Assert.That(driver.Title, Is.EqualTo("Recover your forgotten password"));
        //    }
        //}

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
