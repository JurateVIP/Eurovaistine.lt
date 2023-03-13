using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurovaistine.lt.POM
{
    internal class TopMenu
    {
        IWebDriver driver;

        public TopMenu(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CheckTopMeniuLayout()
        {
            By element = By.XPath("//img[@class='logo']");
            driver.FindElement(element);
        }
        public void GoInTheCart()
        {
            IWebElement element = driver.FindElement(By.Id("cart-block"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }
        public void CheckSearchBar(string elementName)
        {
            By searchBar = By.XPath("(//input[@type = 'search'])[2]");
            driver.FindElement(searchBar).SendKeys(elementName + Keys.Enter);
        }
    }
}
