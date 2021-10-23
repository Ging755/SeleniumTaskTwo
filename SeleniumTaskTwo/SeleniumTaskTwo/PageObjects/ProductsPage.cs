using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        public IWebElement AddToCartButton => ProductItems.FirstOrDefault().FindElement(By.XPath(".//button"));
        public SelectElement FillterDropDown => new SelectElement(_driver.FindElement(By.ClassName("product_sort_container")));

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
    
        public void SelectFilterOption(string filterOption)
        {
            FillterDropDown.SelectByValue(filterOption);
        }
    
        public IWebElement GetFirstProductPrice()
        {
            return ProductItems.FirstOrDefault().FindElement(By.XPath(".//div[@class='inventory_item_price']"));
        }
    }
}
