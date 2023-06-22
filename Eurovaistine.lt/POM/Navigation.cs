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
            generalMethods.ScrollAndClickElementByXpath("(//a[@class='productCard'])[" + itiem + "]");
            generalMethods.ClickElementByXpath("(//button[@data-handler='addToCart'])[1]");
        }
        public string GetItemPriceAndName(int itiem)
        {
            IWebElement itemPrice = generalMethods.FindElementByXpath("(//div[contains(@class,'productPrice')])[" + itiem + "]");
            IWebElement itemName = generalMethods.FindElementByXpath("(//div[@class='title'])[" + itiem + "]");
            return itemPrice.Text + itemName.Text;
        }
        public void CloseAd()
        {
            try
            {
                IWebElement closeSecondAd = generalMethods.ExplisitWait("//button[contains(@class,'close-action')]");
                closeSecondAd.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
