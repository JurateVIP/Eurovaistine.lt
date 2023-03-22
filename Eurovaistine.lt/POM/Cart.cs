using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurovaistine.lt.POM
{
    internal class Cart
    {
        IWebDriver driver;
        GeneralMethods generalMethods;

        public Cart(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }
        public string GetItemPriceandNameInTheCart()
        {
            IWebElement itemprice = generalMethods.FindElementByXpath("//div[@class='cartUnitPrice']");
            IWebElement itemNameInTheCart = generalMethods.FindElementByXpath("//div[@class='productName']");
            return itemprice.Text + itemNameInTheCart.Text;
        }
    }
}
