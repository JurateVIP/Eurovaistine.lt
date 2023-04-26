using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eurovaistine.lt.POM
{
    internal class ProductsPage
    {
        // Šitas kintamasis nenaudojamas
        // Jeigu yra laikomas ateičiai komentaro reiktų
        // kitu atveju galima tiesiog ištrinti
        IWebDriver driver;
        GeneralMethods generalMethods;

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }
        public void CheckProductsSortingByPrice()
        {
            generalMethods.ScrollAndClickElementByXpath("(//select[@id='sort-box'])[2]");
            generalMethods.ScrollAndClickElementByXpath("(//option[@value='price'])[2]");
            IReadOnlyCollection<IWebElement> prices = generalMethods.FindAllElementsByXpath("//div[@class='product-card--price']");

            List<double> allPrices = new List<double>();
            foreach (IWebElement el in prices)
            {
                string onePrice = el.Text.Substring(0, el.Text.Length - 2);
                double otherPrices = double.Parse(onePrice);
                allPrices.Add(otherPrices);
            }
            for (int i = 0; i < allPrices.Count - 1; i++)
            {
                if (allPrices[i] > allPrices[i + 1])
                {
                    // Čia vieta tam pačiam komentarui kaip ir prieš tai 
                    // apie assertus. Ne klaida.
                    Assert.Fail("Products not sorted from lowest price to highest.");
                }
            }
        }
        public void CheckProductsSortingByAlphabet()
        {
            generalMethods.ScrollAndClickElementByXpath("(//select[@id='sort-box'])[2]");
            generalMethods.ScrollAndClickElementByXpath("(//option[@value='title'])[2]");
            // Čia gaunasi labai ilga eilute.
            // Vėlgi nuo skonio priklauso bet aš 
            // vietoj tipo čia parašyčiau tiesiog var
            // var productNames = generalMethods.FindAllElementsByXpath("//div[@class='product-card--title']");
            // ir jeigu eilute vis dar ilga nukelciau viską po ligybes i naują eilutę.
            IReadOnlyCollection<IWebElement> productNames = generalMethods.FindAllElementsByXpath("//div[@class='product-card--title']");

            List<char> allproductNames = new List<char>();
            foreach (IWebElement name in productNames)
            {
                // Labai sudėtingai atrodo imate pirmą raidę
                // užtektų tiesiog name[0];
                // char firstLetter = name.Text[0];
                // o jeigu norite kaip nors fancy tai:
                // foreach (char firstLetter in productNames.Select(n => n.Text[0]))
                // bet tokiu atveju vel deti i sarasa nera tikslo
                // tai visa sita funkcija galima perrasyti ziureti 86 eilute
                string allNames = name.Text.Substring(0, 1);
                // firstletter -> firstLetter
                char firstletter = char.Parse(allNames.ToString());

                allproductNames.Add(firstletter);
            }
            for (int i = 0; i < allproductNames.Count - 1; i++)
            {
                if (allproductNames[i] > allproductNames[i + 1])
                {
                    // Čia vieta tam pačiam komentarui kaip ir prieš tai 
                    // apie assertus. Ne klaida.
                    Assert.Fail("Products not sorted by alphabet.");
                }
            }
        }
        public bool IsProductsSortingByAlphabet()
        {
            generalMethods.ScrollAndClickElementByXpath("(//select[@id='sort-box'])[2]");
            generalMethods.ScrollAndClickElementByXpath("(//option[@value='title'])[2]");
            var productsFirstLetter = 
                generalMethods.FindAllElementsByXpath("//div[@class='product-card--title']")
                .Select(el => el.Text[0])
                .ToList();
            for (int i = 0; i < productsFirstLetter.Count - 1; i++)
                if (productsFirstLetter[i] > productsFirstLetter[i + 1]) 
                    return false;
            return true;
        }

    }
}
