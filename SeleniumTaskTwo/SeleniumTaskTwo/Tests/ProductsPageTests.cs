using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumTaskTwo.PageObjects;
using System;
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

        /// <summary>
        /// Tests if products are being displayed
        /// </summary>
        [Test]
        public void ProductsDisplayed()
        {
            ProductsPage productsPage = new ProductsPage();
            Assert.IsTrue(productsPage.AnyProductItemsDisplayed());
        }

        /// <summary>
        /// Tests add to cart funtion
        /// </summary>
        [Test]
        public void AddToCart()
        {
            ProductsPage productsPage = new ProductsPage();
            Assert.IsTrue(productsPage.AddToCart());
        }


        /// <summary>
        /// Tests remove from cart function
        /// </summary>
        [Test]
        public void RemoveFromCart()
        {
            ProductsPage productsPage = new ProductsPage();
            Assert.IsTrue(productsPage.AddToCart());
            Assert.IsTrue(productsPage.RemoveFromCart());
        }

        /// <summary>
        /// Tests filtering highest to lowest price funtion
        /// </summary>
        [Test]
        public void FilterPriceHighToLow()
        {
            ProductsPage productsPage = new ProductsPage();
            productsPage.SelectFilterOption("hilo");
            Assert.IsTrue(productsPage.GetFirstProductPrice().Text.Equals(_repository.GetHighestProductPrice()));
        }


        /// <summary>
        /// Test filtering lowest to highest price funtion
        /// </summary>
        [Test]
        public void FilterPriceLowToHigh()
        {
            ProductsPage productsPage = new ProductsPage();
            productsPage.SelectFilterOption("lohi");
            Assert.IsTrue(productsPage.GetFirstProductPrice().Text.Equals(_repository.GetLowestProductPrice()));
        }

        [TearDown]
        public void CleanUp()
        {
            MainWebDriver.Driver.Close();
        }
    }
}
