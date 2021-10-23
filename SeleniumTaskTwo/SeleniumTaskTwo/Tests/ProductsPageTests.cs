using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumTaskTwo.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTaskTwo
{
    class ProductsPageTests
    {
        [SetUp]
        public void Initilize()
        {
            MainWebDriver.Driver = new ChromeDriver();

            //Navigate to login Page
            MainWebDriver.Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            //Complete login to reach products page
            LoginPage loginPage = new LoginPage();
            loginPage.Login("standard_user", "secret_sauce");
        }

        [Test]
        public void ProductsDisplayed()
        {
            ProductsPage productsPage = new ProductsPage();
            Assert.IsTrue(productsPage.AnyProductItemsDisplayed());
        }

        [Test]
        public void AddToCart()
        {
            ProductsPage productsPage = new ProductsPage();
            Assert.IsTrue(productsPage.AddToCart());
        }

        [Test]
        public void RemoveFromCart()
        {
            ProductsPage productsPage = new ProductsPage();
            Assert.IsTrue(productsPage.AddToCart());
            Assert.IsTrue(productsPage.RemoveFromCart());
        }

        [TearDown]
        public void CleanUp()
        {
            MainWebDriver.Driver.Close();
        }
    }
}
