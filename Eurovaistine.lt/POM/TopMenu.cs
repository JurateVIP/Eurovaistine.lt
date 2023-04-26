using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Eurovaistine.lt.POM
{
    internal class TopMenu
    {
        DefaultWait<IWebDriver> wait;
        GeneralMethods generalMethods;

        public TopMenu(IWebDriver driver)
        {
            generalMethods = new GeneralMethods(driver);
            wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public void CheckTopMeniuLayout()
        {
            wait.Until(x => x.FindElement(By.XPath("//img[@class='logo']")));
        }
        public void GoInTheCart()
        {
            generalMethods.ClickElementById("cart-block");
        }
        public void WriteInSearchBar(string elementName)
        {
            IWebElement element = wait.Until(x => x.FindElement(By.XPath("(//input[@type = 'search'])[2]")));
            element.SendKeys(elementName + Keys.Enter);
        }
    }
}
