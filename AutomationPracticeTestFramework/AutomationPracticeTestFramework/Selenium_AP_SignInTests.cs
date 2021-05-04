using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace AutomationPracticeTestFramework
{
    public class Selenium_AP_SignInTests
    {
        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickTheSignInLink_ThenIGoToTheSignInPage()
        {
            //create a new web driver instance so we can interact with the page
            using (IWebDriver driver = new ChromeDriver())
            {
                //Maximize the browser so it is full screen
                driver.Manage().Window.Maximize();
                //navigate through the automation practice site
                driver.Navigate().GoToUrl("http://automationpractice.com/");
                //get a reference to the sign in link
                IWebElement signInLink = driver.FindElement(By.LinkText("Sign in"));
                //Act - click the sign in link
                signInLink.Click();
                //wait to ensure a response
                Thread.Sleep(5000);
                //assert - that we are on the sign in page
                Assert.That(driver.Title, Is.EqualTo("Login - My Store"));

            }
        }

        [Test]
        public void GivenIAmOnTheSignInPage_AnIEnterA4DigitPassword_WhenICLickTheSignInButton_ThenIGetAnErrorMessage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Manage().Window.Maximize();

                //navigate through the sign in page
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");

                //find the email and password text feilds and get a reference to those feilds
                IWebElement emailFeilds = driver.FindElement(By.Id("email"));
                emailFeilds.SendKeys("testing@snailmail.com");
                IWebElement passwordFeild = driver.FindElement(By.Id("passwd"));
                passwordFeild.SendKeys("four");
                //get a reference to the sign in button
                IWebElement signInButton = driver.FindElement(By.Id("SubmitLogin"));

                //Act - click the login button
                signInButton.Click();

                //Assert
                //get a reference to the alert element
                IWebElement alert = driver.FindElement(By.ClassName("alert"));
                //check the error message is correct
                Assert.That(alert.Text.Contains("Invalid password"));
            }
        }

        [Test]
        public void GivenIAmOntheSignInPage_WhenIFailedToProvideAnEmailAddress_ThenIReceiveAnErrorMessage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Manage().Window.Maximize();

                //navigate through the sign in page
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");

                IWebElement emailFeilds = driver.FindElement(By.Id("email"));
                emailFeilds.SendKeys(" ");
                IWebElement passwordFeild = driver.FindElement(By.Id("passwd"));
                passwordFeild.SendKeys("four");
                //get a reference to the sign in button
                IWebElement signInButton = driver.FindElement(By.Id("SubmitLogin"));

                signInButton.Click();

                //Assert
                IWebElement errorMessage = driver.FindElement(By.ClassName("alert"));
                Assert.That(errorMessage.Text.Contains("An email address required."));
            }
                
        }

        [Test]
        public void GivenIAmOnTheSignInPage_WhenISelectIForgotThePassWord_ThenThePageShouldNavigateToForgottenPasswordPage()
        {
            using(IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");

                

                IWebElement forgottenPassword = driver.FindElement(By.ClassName("lost_password"));
                forgottenPassword.Click();

                Thread.Sleep(5000);
                Assert.That(driver.Title, Is.EqualTo("Recover your forgotten password"));
            }
        }
    }
}
