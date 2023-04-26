﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurovaistine.lt.POM
{
    internal class TopMenu
    {
        // Šitas kintamasis nenaudojamas
        // Jeigu yra laikomas ateičiai komentaro reiktų
        // kitu atveju galima tiesiog ištrinti
        IWebDriver driver;
        DefaultWait<IWebDriver> wait;
        GeneralMethods generalMethods;

        public TopMenu(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
            wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public void CheckTopMeniuLayout()
        {
            // nelabai supratau? Cia gal errora gaudai?
            // Is kodo nelabai mato intencija
            IWebElement element = wait.Until(x => x.FindElement(By.XPath("//img[@class='logo']")));
        }
        public void GoInTheCart()
        {
            try 
            {
               generalMethods.ClickElementByXpath("//a[@class='popup-btn add-to-cart-popup']");
            } 
            catch(Exception e)
            {
                generalMethods.ScrollAndClickElementByXpath("//span[@class='svgIcon']");
            }

        }
        public void WriteInSearchBar(string elementName)
        {
            IWebElement element = wait.Until(x => x.FindElement(By.XPath("(//input[@type = 'search'])[2]")));
            element.SendKeys(elementName + Keys.Enter);
        }
    }
}
