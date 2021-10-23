using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumTaskTwo.PageObjects;
using System;

namespace SeleniumTaskTwo
{
    class Program
    {
        [SetUp]
        public void Initilize()
        {
            MainWebDriver.Driver = new ChromeDriver();

            //Navigate to login Page
            MainWebDriver.Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void LoginScreenDisplayed()
        {
            LoginPage loginPage = new LoginPage();
            //Login page should be displayed along with username, password input and login button
            Assert.IsTrue(loginPage.LoginPageDisplayed());
        }

        [Test]
        public void IncorrectUserNameOrPassword()
        {
            LoginPage loginPage = new LoginPage();
            //Checking if corret error message is displayed when username or password are incorrect
            Assert.IsTrue(loginPage.Login("WrongUserName", "WrongPassword").Text.Equals("Epic sadface: Username and password do not match any user in this service"));
        }

        [Test]
        public void EmptyUsername()
        {
            LoginPage loginPage = new LoginPage();
            //Checking if corret error message is displayed when username is empty
            Assert.IsTrue(loginPage.Login("", "WrongPassword").Text.Equals("Epic sadface: Username is required"));
        }

        [Test]
        public void EmptyPassword()
        {
            LoginPage loginPage = new LoginPage();
            //Checking if corret error message is displayed when password is empty
            Assert.IsTrue(loginPage.Login("Username", "").Text.Equals("Epic sadface: Password is required"));
        }

        [Test]
        public void SuccessfulLogin()
        {
            LoginPage loginPage = new LoginPage();
            //After successfull login, products page should be displayed
            Assert.IsTrue(loginPage.Login("standard_user", "secret_sauce").Displayed);
        }

        [TearDown]
        public void CleanUp()
        {
            MainWebDriver.Driver.Close();
        }
    }
}
