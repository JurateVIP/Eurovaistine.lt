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
        GeneralMethods generalMethods;

        public Cart(IWebDriver driver)
        {
            generalMethods = new GeneralMethods(driver);
        }
        public string GetItemPriceAndNameInTheCart()
        {
            IWebElement itemPrice = generalMethods.FindElementByXpath("//div[@class='cartUnitPrice']");
            IWebElement itemNameInTheCart = generalMethods.FindElementByXpath("//div[@class='productName']");
            return itemPrice.Text + itemNameInTheCart.Text;
        }
    }
}
