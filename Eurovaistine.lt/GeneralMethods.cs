using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurovaistine.lt
{
    internal class GeneralMethods
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> wait;

        public GeneralMethods(IWebDriver driver)
        {
            this.driver = driver;
            wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }
        public void ClickElementByXpath(string xpath)
        {
            IWebElement element = wait.Until(x => x.FindElement(By.XPath(xpath)));
            element.Click();
        }
        public void ScrollAndClickElementByXpath(string xpath)
        {
            IWebElement element = wait.Until(x => x.FindElement(By.XPath(xpath)));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }
        public void ScrollAndClickElementByID(string id)
        {
            IWebElement element = wait.Until(x => x.FindElement(By.Id(id)));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }
        public void EnterTextById(string id, string text)
        {
            IWebElement element = wait.Until(x => x.FindElement(By.Id(id)));
            element.SendKeys(text);
        }
        // šitoje vietoje ne klaida bet jeigu jau turi kelis metodus pagal kažką
        // visai variantas būtų dar viena abstrakcija deti
        // plius nebutina saugotis kaip kintamojo ir iskarto
        // grazinti 89 eilute pavyzdys kaip butu galima pakeisti
        public IWebElement FindElementById(string id)
        {
            IWebElement element = wait.Until(x => x.FindElement(By.Id(id)));
            return element;
        }
        public IWebElement FindElementByXpath(string xpath)
        {
            IWebElement element = wait.Until(x => x.FindElement(By.XPath(xpath)));
            return element;

        }
        public IReadOnlyCollection<IWebElement> FindAllElementsByXpath(string xpath)
        {
            IReadOnlyCollection <IWebElement> element = wait.Until(x => x.FindElements(By.XPath(xpath)));
            return element;
        }
        // Explisitwait -> ExplisitWait -> ExplicitWait
        public IWebElement Explisitwait(string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0,0,0,30));
            wait.Until(x => x.FindElement(By.XPath(xpath)).Displayed);
            return driver.FindElement(By.XPath(xpath));
        }
        // Typo: TakeScreanShot -> TakeScreenShot
        public void TakeScreanShot()
        {
            Screenshot ss = driver.TakeScreenshot();            
            string screenshot = "screenshot" + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss") + ".jpg";
            // Absoliutus path'as mano kompiuteryje neveiks.
            //ss.SaveAsFile("C:\\Users\\Jurate\\source\\repos\\Eurovaistine.lt\\Eurovaistine.lt\\" + screenshot);
            ss.SaveAsFile(screenshot);
        }

        // Cia prasideda pavyzdys
        public IWebElement FindElementBy(By by) => wait.Until(x => x.FindElement(by));
        public IWebElement FindElementById2(string id) => FindElementBy(By.Id(id));
        public IWebElement FindElementByXPath2(string xPath) => FindElementBy(By.XPath(xPath));

    }
}
