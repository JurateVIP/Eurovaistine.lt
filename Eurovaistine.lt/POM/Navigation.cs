using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium.Support.UI;

namespace Eurovaistine.lt.POM
{
    internal class Navigation
    {
        IWebDriver driver;
        GeneralMethods generalMethods;

        public Navigation(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }
        public void NavigateFromMainPage(string parent, string child)
        {
            IWebElement MainCategory = generalMethods.FindElementByXpath("//a[contains(text(),'" + parent + "')]");
            Actions action = new Actions(driver);
            action.MoveToElement(MainCategory).Perform();
            generalMethods.ClickElementByXpath("//span[contains(text(),'" + child + "')]//parent::a");
        }
        public void AddItemsToTheCart(int itemNumber)
        {
            generalMethods.ScrollAndClickElementByXpath("(//div[@class='product-card']//button[@type='submit'])[" + itemNumber + "]");
        }
        public string GetItemPriceAndName(int itemNumber)
        {
            IWebElement itemprice = generalMethods.FindElementByXpath("(//div[@class='product-card--price'])[" + itemNumber + "]");
            IWebElement itemName = generalMethods.FindElementByXpath("(//div[@class='product-card--title'])[" + itemNumber + "]");
            return itemprice.Text + itemName.Text;
        }
        public void CloseAd()
        {
            try
            {
                IWebElement closeAd = generalMethods.Explisitwait("//button[contains(@class,'close-action')]");
                closeAd.Click();
            }
            catch (Exception e){
                Console.WriteLine(e);
            }
        }
    }
}
