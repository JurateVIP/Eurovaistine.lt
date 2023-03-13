using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurovaistine.lt.POM
{
    internal class ProductCard
    {
        IWebDriver driver;
        public ProductCard(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void GoInTheProductCard(int itemNumber)
        {
            IWebElement element = driver.FindElement(By.XPath("(//a[@class='product-card--link'])["+ itemNumber + "]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }
        public string SelectedItemPriceAndName()
        {
            By itemprice = By.XPath("(//div[@class='product--price'])[1]");
            By itemName = By.XPath("//h1[@class='product-title']");

            return driver.FindElement(itemprice).Text + driver.FindElement(itemName).Text;
        }
        public string ItemPriceAndNameAtTheBottom()
        {
            By itemprice = By.XPath("(//div[@class='product--price'])[2]");
            By itemName = By.XPath("//div[contains(@class, 'product-title')]");

            return driver.FindElement(itemprice).Text + driver.FindElement(itemName).Text;
        }
    }
}
