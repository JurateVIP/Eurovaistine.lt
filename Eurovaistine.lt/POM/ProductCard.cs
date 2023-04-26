using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Eurovaistine.lt.POM
{
    internal class ProductCard
    {
        GeneralMethods generalMethods;

        public ProductCard(IWebDriver driver)
        {
            generalMethods = new GeneralMethods(driver);
        }
        public void GoInTheProductCard(int itemNumber)
        {
            generalMethods.ScrollAndClickElementByXpath("(//a[@class='productCard'])[" + itemNumber + "]");
        }
        public string ItemPriceAndNameAtTheTopOfTheCard()
        {
            IWebElement itemPrice = generalMethods.FindElementByXpath("(//div[@class='product--price'])[1]");
            IWebElement itemName = generalMethods.FindElementByXpath("//h1[@class='product-title']");
            return itemPrice.Text + itemName.Text;
        }
        public string ItemPriceAndNameAtTheBottomOfTheCard()
        {
            IWebElement itemPrice = generalMethods.FindElementByXpath("(//div[@class='product--price'])[2]");
            IWebElement itemName = generalMethods.FindElementByXpath("//div[contains(@class, 'product-title')]");
            return itemPrice.Text + itemName.Text;
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
