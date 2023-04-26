using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurovaistine.lt.POM
{
    internal class ProductCard
    {
        // Šitas kintamasis nenaudojamas
        // Jeigu yra laikomas ateičiai komentaro reiktų
        // kitu atveju galima tiesiog ištrinti
        IWebDriver driver;
        GeneralMethods generalMethods;

        public ProductCard(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }
        public void GoInTheProductCard(int itemNumber)
        {
            generalMethods.ScrollAndClickElementByXpath("(//a[@class='product-card--link'])[" + itemNumber + "]");
        }
        // Čia jau į akis krenta, kai kurie metodai iš mažosios kiti iš didžiosios
        // Viskas gerai turėti stilių nepagal standartus, nes jie keičiasi
        // ir būna įvairūs, bet būtų gerai laikytis vieno
        public string itemPriceAndNameAtTheTopOfTheCard()
        {
            // itemprice -> itemPrice
            IWebElement itemprice = generalMethods.FindElementByXpath("(//div[@class='product--price'])[1]");
            IWebElement itemName = generalMethods.FindElementByXpath("//h1[@class='product-title']");
            return itemprice.Text + itemName.Text;
        }
        public string itemPriceAndNameAtTheBottomOfTheCard()
        {
            // itemprice -> itemPrice
            IWebElement itemprice = generalMethods.FindElementByXpath("(//div[@class='product--price'])[2]");
            IWebElement itemName = generalMethods.FindElementByXpath("//div[contains(@class, 'product-title')]");
            return itemprice.Text + itemName.Text;
        }
        public void CheckBreadscrumbsCount()
        {
            IReadOnlyCollection<IWebElement> breadScrumbs = generalMethods.FindAllElementsByXpath("//li[@itemprop = 'itemListElement']");
            int breadScrumbsCount = breadScrumbs.Count();
            // Man rodos Assertas, automatiškai pasako tokią žinutė,
            // Šitas kintamasis skirtas papildomai informacijai
            // Plius nežinau kaip kitas dėstytojas sakė,
            // ar koks stilius dabar vyrauja, bet aš būčiau už
            // tai kad Assertai būtų testo funkcijoje pragrindinėje
            // o šitos pagalbinės gražintų informaciją kurią reikia
            // Assert'inti
            Assert.AreEqual(4, breadScrumbsCount, "Expected 4, but got - " + breadScrumbsCount);
        }
        // Mhm čia toks tikrinimas su Exceptionais.
        // Veikia bet man nelabai patinka
        // geriau tiesiog gražinti tą elementą ir patikrinti ar
        // jis nėra null. Bet tik dėl kodo gražumo
        public void CheckWishlistButton()
        {
            generalMethods.FindElementByXpath("//div[@class = 'wishlist--product-page']");
        }
        public void CheckProductInputButton()
        {
            generalMethods.FindElementByXpath("(//div[@class='product-input'])[1]");
        }
        public void CheckProductInformationTab()
        {
            generalMethods.FindElementByXpath("//div[@class ='product-tabs']");
        }
    }
}
