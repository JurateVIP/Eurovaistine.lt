using NUnit.Framework;
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
        GeneralMethods generalMethods;

        public ProductCard(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }
        public void GoInTheProductCard(int itemNumber)
        {
            IWebElement element = driver.FindElement(By.XPath("(//a[@class='product-card--link'])["+ itemNumber + "]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }
        public string itemPriceAndNameAtTheTopOfTheCard()
        {
            By itemprice = By.XPath("(//div[@class='product--price'])[1]");
            By itemName = By.XPath("//h1[@class='product-title']");

            return driver.FindElement(itemprice).Text + driver.FindElement(itemName).Text;
        }
        public string itemPriceAndNameAtTheBottomOfTheCard()
        {
            By itemprice = By.XPath("(//div[@class='product--price'])[2]");
            By itemName = By.XPath("//div[contains(@class, 'product-title')]");

            return driver.FindElement(itemprice).Text + driver.FindElement(itemName).Text;
        }
        public void CheckBreadscrumbsCount()
        {
            By breadScrumbs = By.XPath("//li[@itemprop = 'itemListElement']");
            int breadScrumbsCount = driver.FindElements(breadScrumbs).Count();
            Assert.AreEqual(4, breadScrumbsCount, "Expected 4, but got - " + breadScrumbsCount);
        }
        public void CheckWishlistButton()
        {
            generalMethods.FindElementByXpath("//div[@class = 'wishlist--product-page']");
        }
        public void CheckProductInputButton()
        {
            generalMethods.FindElementByXpath("(//div[@class='product-input'])[1]");
        }
        public void CheckProductInformationTab()
        {
            generalMethods.FindElementByXpath("//div[@class ='product-tabs']");
        }
    }
}
