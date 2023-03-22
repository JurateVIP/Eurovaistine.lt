﻿using Eurovaistine.lt.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eurovaistine.lt
{
    public class Main
    {
        static IWebDriver driver;
        TopMenu topMenu;
        Navigation nav;
        Cart cart;
        GeneralMethods generalMethods;
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
            generalMethods.ScrollAndClickElementByID("onetrust-accept-btn-handler");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
        }

        [Test]
        public void AddProductToTheCart()
        {
            topMenu.CheckTopMeniuLayout();
            nav.NavigateFromMainPage("Vaistai nereceptiniai", "Gripui");
            topMenu.CheckTopMeniuLayout();
            Thread.Sleep(3000);
            nav.AddItemsToTheCart(2);
            string itemPriceAndName = nav.GetItemPriceAndName(2);
            topMenu.GoInTheCart();
            string itemPriceAndNameInTheCart = cart.GetItemPriceandNameInTheCart();
            Assert.AreEqual(itemPriceAndNameInTheCart, itemPriceAndName, "Price or name doesn't match with added item info.");
        }
        [Test]
        public void CheckProductCardVisibility()
        {
            topMenu.WriteInSearchBar("Ibuprom");
            string itemPriceAndName = nav.GetItemPriceAndName(1);
            productCard.GoInTheProductCard(1);
            topMenu.CheckTopMeniuLayout();
            string itemPriceAndNameAtTheTopOfTheCard = productCard.itemPriceAndNameAtTheTopOfTheCard();
            string itemPriceAndNameAtTheBottomOfTheCard = productCard.itemPriceAndNameAtTheBottomOfTheCard();
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
            productsPage.CheckProductsSortingByPrice();
            productsPage.CheckProductsSortingByAlphabet();
        }

        [Test]
        public void CheckChatBox()
        {
            productsPage.CheckChatBoxVisability();
        }

        [Test]
        public void CheckRegistration()
        {
            string emailForRegistration = registration_login.FillRegistrationForm();
            registration_login.CheckOrAutomaticallyLogInAfterRegistration(emailForRegistration);
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
            //driver.Quit();
        }
    }
}
