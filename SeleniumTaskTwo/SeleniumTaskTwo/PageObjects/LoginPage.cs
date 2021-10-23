using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTaskTwo.PageObjects
{
    class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage()
        {
            _driver = MainWebDriver.Driver;
        }

        public IWebElement UserName => _driver.FindElement(By.Id("user-name"));
        public IWebElement Password => _driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));
        public IWebElement ErrorMessage { get; set; }

        public bool LoginPageDisplayed()
        {
            return (UserName.Displayed && Password.Displayed && LoginButton.Displayed) ;
        }

        public IWebElement Login(string username, string password)
        {
            UserName.SendKeys(username);
            Password.SendKeys(password);
            LoginButton.Submit();

            try
            {
                return _driver.FindElement(By.XPath("//div[@class='error-message-container error']/h3"));
            }
            catch
            {          
                return _driver.FindElement(By.Id("inventory_container"));
            }
        }
    }
}
