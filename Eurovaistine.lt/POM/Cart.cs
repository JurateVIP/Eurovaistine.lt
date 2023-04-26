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
        // Šitas kintamasis nenaudojamas
        // Jeigu yra laikomas ateičiai komentaro reiktų
        // kitu atveju galima tiesiog ištrinti
        IWebDriver driver;
        GeneralMethods generalMethods;

        public Cart(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }
        // GetItemPriceandNameInTheCart -> GetItemPriceAndNameInTheCart
        // (kapitalizuojame visus zodzius del skaitomumo)
        public string GetItemPriceandNameInTheCart()
        {
            // itemprice -> itemPrice
            // Skaitomumas yra labai svarbu rašant kodą
            // nes kaip yra man vienas indžinierius pasakęs
            // kodas yra rašomas vieną kartą
            // tada skaitomas 9
            IWebElement itemprice = generalMethods.FindElementByXpath("//div[@class='cartUnitPrice']");
            IWebElement itemNameInTheCart = generalMethods.FindElementByXpath("//div[@class='productName']");
            return itemprice.Text + itemNameInTheCart.Text;
        }
    }
}
