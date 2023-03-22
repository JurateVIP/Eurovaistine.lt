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
            generalMethods.ScrollAndClickElementByXpath("(//a[@class='product-card--link'])[" + itemNumber + "]");
        }
        public string itemPriceAndNameAtTheTopOfTheCard()
        {
            IWebElement itemprice = generalMethods.FindElementByXpath("(//div[@class='product--price'])[1]");
            IWebElement itemName = generalMethods.FindElementByXpath("//h1[@class='product-title']");
            return itemprice.Text + itemName.Text;
        }
        public string itemPriceAndNameAtTheBottomOfTheCard()
        {
            IWebElement itemprice = generalMethods.FindElementByXpath("(//div[@class='product--price'])[2]");
            IWebElement itemName = generalMethods.FindElementByXpath("//div[contains(@class, 'product-title')]");
            return itemprice.Text + itemName.Text;
        }
        public void CheckBreadscrumbsCount()
        {
            IReadOnlyCollection<IWebElement> breadScrumbs = generalMethods.FindAllElementsByXpath("//li[@itemprop = 'itemListElement']");
            int breadScrumbsCount = breadScrumbs.Count();
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
