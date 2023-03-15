﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurovaistine.lt.POM
{
    internal class ProductsPage
    {
        IWebDriver driver;
        GeneralMethods generalMethods;

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }
        public void CheckProductsSortingByPrice()
        {
            generalMethods.ClickElement("(//select[@id='sort-box'])[2]");
            generalMethods.ClickElement("(//option[@value='price'])[2]");
            By prices = By.XPath("//div[@class='product-card--price']");

            List<double> allPrices = new List<double>();
            foreach (IWebElement el in driver.FindElements(prices))
            {
                string onePrice = el.Text.Substring(0, el.Text.Length - 2);
                double otherPrices = double.Parse(onePrice);
                allPrices.Add(otherPrices);
            }
            for (int i = 0; i < allPrices.Count - 1; i++)
            {
                if (allPrices[i] > allPrices[i + 1])
                {
                    Assert.Fail("Products not sorted from lowest price to highest.");
                }
            }
        }
        public void CheckProductsSortingByAlphabet()
        {
            generalMethods.ClickElement("(//select[@id='sort-box'])[2]");
            generalMethods.ClickElement("(//option[@value='title'])[2]");
            By productNames = By.XPath("//div[@class='product-card--title']");

            List<char> allproductNames = new List<char>();
            foreach (IWebElement name in driver.FindElements(productNames))
            {
                string allNames = name.Text.Substring(0, 1);
                char firstletter = char.Parse(allNames.ToString());

                allproductNames.Add(firstletter);
            }
            for (int i = 0; i < allproductNames.Count - 1; i++)
            {
                if (allproductNames[i] > allproductNames[i + 1])
                {
                    Assert.Fail("Products not sorted by alphabet.");
                }
            }
        }
    }
}