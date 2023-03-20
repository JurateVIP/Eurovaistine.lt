using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurovaistine.lt
{
    internal class GeneralMethods
    {
        IWebDriver driver;
        public GeneralMethods(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void SimpleClick(string xpath)
        {
            By button = By.XPath(xpath);
            driver.FindElement(button).Click();
        }
        public void ClickElementByXpath(string xpath)
        {
            IWebElement el = driver.FindElement(By.XPath(xpath));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", el);
            el.Click();
        }
        public void ClickElementByID(string id)
        {
            IWebElement el = driver.FindElement(By.Id(id));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", el);
            el.Click();
        }
        public void EnterTextByXpath(string xpath, string text)
        {
            By textField = By.XPath(xpath);
            driver.FindElement(textField).SendKeys(text);
        }
        public void EnterTextById(string id, string text)
        {
            By textField = By.Id(id);
            driver.FindElement(textField).SendKeys(text);
        }
        public void FindElementById(string id)
        {
            By elementById = By.XPath(id);
            driver.FindElement(elementById);
        }
        public void FindElementByXpath(string xpath)
        {
            By elementByXpath = By.XPath(xpath);
            driver.FindElement(elementByXpath);
        }
    }
}
