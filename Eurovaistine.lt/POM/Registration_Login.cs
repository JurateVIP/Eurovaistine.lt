using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Eurovaistine.lt.POM
{
    internal class Registration_Login
    {
        GeneralMethods generalMethods;
        DefaultWait<IWebDriver> wait;

        public Registration_Login(IWebDriver driver)
        {
            generalMethods = new GeneralMethods(driver);
            wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }
        public string emailAndPassword = "TEST202303203@test.lt";

        private string GenerateEmailForRegistration()
        {
            Random random = new Random();

            string emailForRegistration = random.Next().ToString() + "Aa@test.lt";
            return emailForRegistration;
        }

        public string FillRegistrationForm()
        {
            string emailAndPasswordForRegistration = GenerateEmailForRegistration();
            generalMethods.ScrollAndClickElementByID("user-block");
            generalMethods.EnterTextById("customer_registration_email", emailAndPasswordForRegistration);
            generalMethods.EnterTextById("customer_registration_user_plainPassword_first", emailAndPasswordForRegistration);
            generalMethods.EnterTextById("customer_registration_user_plainPassword_second", emailAndPasswordForRegistration);
            generalMethods.ScrollAndClickElementByXpath("//input[contains(@id, 'acceptSensitiveData')]");            
            generalMethods.ScrollAndClickElementByXpath("(//button[@class= 'btn btn-green'])[1]");
            return emailAndPasswordForRegistration;
        }
        public void CheckLogInAfterRegistration(string emailForRegistration)
        {
            IWebElement userNameVisability = wait.Until(x => x.FindElement(By.XPath("//span[contains(@class,'headerUserName')]")));
            string userNameAfterLogIn = userNameVisability.Text;
            string userName = emailForRegistration.Split('@')[0];
            Assert.AreEqual(userName, userNameAfterLogIn, "Didn't log in after registration");
        }
        public void FillLogInForm()
        {
            generalMethods.ScrollAndClickElementByID("user-block");
            generalMethods.EnterTextById("_username", emailAndPassword);
            generalMethods.EnterTextById("_password", emailAndPassword);
            generalMethods.ScrollAndClickElementByID("authLoginButton");
        }
        public void CheckLogIn()
        {
            IWebElement userNameVisability = wait.Until(x => x.FindElement(By.XPath("//span[@class='headerUserName d-none d-lg-block']")));
            string userNameAfterLogIn = userNameVisability.Text;
            string userName = emailAndPassword.Split('@')[0];
            Assert.AreEqual(userName, userNameAfterLogIn, "Log in failed");
        }
    }
}
