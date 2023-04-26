using Eurovaistine.lt.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Eurovaistine.lt
{
    public class Main
    {
        static IWebDriver driver;
        TopMenu topMenu;
        Navigation nav;
        Cart cart;
        static GeneralMethods generalMethods;
        ProductCard productCard;
        ProductsPage productsPage;
        Registration_Login registration_login;

        [SetUp]
        public void SETUP()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            driver = new ChromeDriver(options);

            generalMethods = new GeneralMethods(driver);
            topMenu = new TopMenu(driver);
            nav = new Navigation(driver);
            cart = new Cart(driver);
            productCard = new ProductCard(driver);
            productsPage = new ProductsPage(driver);
            registration_login = new Registration_Login(driver);

            driver.Manage().Window.Maximize();
            driver.Url = "https://www.eurovaistine.lt/";
            generalMethods.FindElementById("onetrust-accept-btn-handler").Click();
            nav.CloseAd();
        }
        [Test]
        public void AddProductToTheCart()
        {
            topMenu.CheckTopMeniuLayout();
            nav.NavigateFromMainPage("Vaistai nereceptiniai", "Gripui");
            topMenu.CheckTopMeniuLayout();
            nav.AddItemsToTheCart(2);
            string itemPriceAndName = productCard.ItemPriceAndNameAtTheTopOfTheCard();
            Thread.Sleep(1000);
            topMenu.GoInTheCart();
            string itemPriceAndNameInTheCart = cart.GetItemPriceAndNameInTheCart();
            Assert.AreEqual(itemPriceAndNameInTheCart, itemPriceAndName, "Price or name doesn't match with added item info.");
        }
        [Test]
        public void CheckProductCardVisibility()
        {
            topMenu.WriteInSearchBar("Ibuprom");
            string itemPriceAndName = nav.GetItemPriceAndName(1);
            productCard.GoInTheProductCard(1);
            topMenu.CheckTopMeniuLayout();
            string itemPriceAndNameAtTheTopOfTheCard = productCard.ItemPriceAndNameAtTheTopOfTheCard();
            string itemPriceAndNameAtTheBottomOfTheCard = productCard.ItemPriceAndNameAtTheBottomOfTheCard();
            Assert.AreEqual(itemPriceAndNameAtTheTopOfTheCard, itemPriceAndName, "Price or name on the top doesn't match with selected item info.");
            Assert.AreEqual(itemPriceAndNameAtTheBottomOfTheCard, itemPriceAndName, "Price or name on the bottom doesn't match with selected item info.");
            productCard.CheckBreadscrumbsCount();
            productCard.CheckWishlistButton();
            productCard.CheckProductInputButton();
            productCard.CheckProductInformationTab();
        }

        [Test]
        public void CheckProductListSorting()
        {
            nav.NavigateFromMainPage("Vaistai nereceptiniai", "Gripui");
            productsPage.CheckProductsSortingFromLowestPrice();
            productsPage.CheckProductsSortingFromHigestPrice();
        }

        [Test]
        public void CheckRegistration()
        {
            string emailForRegistration = registration_login.FillRegistrationForm();
            registration_login.CheckLogInAfterRegistration(emailForRegistration);
        }

        [Test]
        public void CheckLogIn()
        {
            registration_login.FillLogInForm();
            registration_login.CheckLogIn();
        }

        [TearDown]
        public static void CloseWindow()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                generalMethods.TakeScreenShot();
            }
            //driver.Quit();
        }
    }

}
