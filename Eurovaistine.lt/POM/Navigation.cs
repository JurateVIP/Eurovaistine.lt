using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using System.Drawing;

namespace Eurovaistine.lt.POM
{
    internal class Navigation
    {
        IWebDriver driver;
        GeneralMethods generalMethods;
        Actions action;

        public Navigation(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
            action = new Actions(driver);

        }
        public void NavigateFromMainPage(string parent, string child)
        {
            IWebElement MainCategory = generalMethods.FindElementByXpath("//a[contains(text(),'" + parent + "')]");
            action.MoveToElement(MainCategory).Perform();
            generalMethods.ClickElementByXpath("//span[contains(text(),'" + child + "')]//parent::a");
        }
        public void AddItemsToTheCart(int itiem)
        {
            generalMethods.ScrollAndClickElementByXpath("(//a[@class='productCard'])["+ itiem + "]");
            generalMethods.ClickElementByXpath("(//button[@data-handler='addToCart'])[1]");
        }
        public string GetItemPriceAndName()
        {
            IWebElement itemprice = generalMethods.FindElementByXpath("(//div[@class='product--price'])[1]");
            IWebElement itemName = generalMethods.FindElementByXpath("//h1[@class='product-title']");
            return itemprice.Text + itemName.Text;
        }
        public void CloseAd()
        {
            try
            {
                IWebElement closeSecondAd = generalMethods.Explisitwait("//button[contains(@class,'PopupCloseButton')]");
                closeSecondAd.Click();
            }
            catch (Exception e){
                Console.WriteLine(e);
            }
        }
    }
}
