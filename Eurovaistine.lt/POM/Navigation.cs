using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Eurovaistine.lt.POM
{
    internal class Navigation
    {
        IWebDriver driver;
        public Navigation(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void NavigateFromMainPage(string parent, string child)
        {
            By ParentCategory = By.XPath("//a[contains(text(),'" + parent + "')]");
            Actions action = new Actions(driver);
            IWebElement ParentCatObj = driver.FindElement(ParentCategory);
            action.MoveToElement(ParentCatObj).Perform();
            By innerCat = By.XPath("//span[contains(text(),'" + child + "')]//parent::a");
            driver.FindElement(innerCat).Click();
        }
        public void AddItemsToTheCart(int itemNumber)
        {
            IWebElement element = driver.FindElement(By.XPath("(//div[@class='product-card']//button[@type='submit'])[" + itemNumber + "]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }
        public string GetItemPriceAndName(int itemNumber)
        {
            By itemprice = By.XPath("(//div[@class='product-card--price'])[" + itemNumber + "]");
            By itemName = By.XPath("(//div[@class='product-card--title'])[" + itemNumber + "]");

            return driver.FindElement(itemprice).Text + driver.FindElement(itemName).Text;
        }
    }
}
