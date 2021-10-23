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
        private TestDataRepository _repository;

        [SetUp]
        public void Initilize()
        {
            MainWebDriver.Driver = new ChromeDriver();
            _repository = new TestDataRepository();

            //Navigate to login Page
            MainWebDriver.Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            //Complete login to reach products page
            LoginPage loginPage = new LoginPage();
            loginPage.Login(_repository.GetCorrectUserName(), _repository.GetCorrectPassword());
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

        [Test]
        public void FilterPriceHighToLow()
        {
            ProductsPage productsPage = new ProductsPage();
            Assert.IsTrue(productsPage.SelectFilterOption("hilo").Text.Equals(_repository.GetHighestProductPrice()));
        }

        [Test]
        public void FilterPriceLowToHigh()
        {
            ProductsPage productsPage = new ProductsPage();
            Assert.IsTrue(productsPage.SelectFilterOption("lohi").Text.Equals(_repository.GetLowestProductPrice()));
        }

        [TearDown]
        public void CleanUp()
        {
            MainWebDriver.Driver.Close();
        }
    }
}
