using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumTaskTwo.PageObjects
{
    class ProductsPage
    {
        private IWebDriver _driver;

        public ProductsPage()
        {
            _driver = MainWebDriver.Driver;
        }

        public IEnumerable<IWebElement> ProductItems => _driver.FindElements(By.ClassName("inventory_item"));
        public IWebElement AddToCartButton => _driver.FindElement(By.XPath("//div[@class='inventory_item']//button"));
        public bool AnyProductItemsDisplayed()
        {
            return ProductItems.Count() > 0;
        }

        public bool AddToCart()
        {
            AddToCartButton.Click();
            return AddToCartButton.Text.Equals("REMOVE");
        }

        public bool RemoveFromCart()
        {
            AddToCartButton.Click();
            return AddToCartButton.Text.Equals("ADD TO CART");
        }
    }
}
