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

        public Cart(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetItemPriceandNameInTheCart()
        {
            By itemPrice = By.XPath("//div[@class='cartUnitPrice']");
            By itemNameInTheCart = By.XPath("//div[@class='productName']");

            return driver.FindElement(itemPrice).Text + driver.FindElement(itemNameInTheCart).Text;
        }
    }
}
