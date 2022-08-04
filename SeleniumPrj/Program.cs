﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V85.CacheStorage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumPrj
{
    internal class Program
    {
        static void HomepageTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            //title
            var title = driver.Title;
            Assert.AreEqual("Madison Island", title);

            //URL
            Console.WriteLine("url " + driver.Url);
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com/about-magento-demo-store/");
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();

            //click on the logo
            driver.FindElement(By.CssSelector("#header > div > a")).Click();
            driver.Quit();
        }

        static void AccountTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            driver.FindElement(By.CssSelector("#header > div > div.skip-links > div > a")).Click();
            driver.Quit();
        }

        static void LanguagesTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            driver.FindElement(By.CssSelector("#select-language")).Click();
            driver.FindElement(By.CssSelector("#select-language > option:nth-child(2)")).Click();
            driver.Quit();
        }

        static void SearchTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            WebElement elem = (WebElement)driver.FindElement(By.CssSelector("div.input-box input"));
            elem.SendKeys("woman");
            elem.Submit();
            driver.Quit();

        }

        static void NewProductListTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            driver.FindElement(By.CssSelector("#nav > ol > li > a")).Click();
            WebElement elem = (WebElement)driver.FindElement(By.CssSelector("body > div > div > div.main-container.col1-layout > div > div.col-main > ul > li"));
            elem.Click();
            Console.WriteLine("Size of the list: "+ driver.FindElements(By.CssSelector("div.col-main > ul > li")).Count()); //size 0
            driver.Quit();
        }

        static void NavigationTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            driver.FindElement(By.CssSelector("#nav > ol > li.level0.nav-5.parent > a")).Click();
            driver.FindElement(By.CssSelector("div.col-main > div.category-products > ul > li:nth-child(2)")).Click();
            driver.Quit();
        }

        static void AddProductToCartTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            driver.FindElement(By.CssSelector("#nav > ol > li.level0.nav-5.parent > a")).Click();
            driver.FindElement(By.CssSelector("div.col-main > div.category-products > ul > li:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector("#swatch18")).Click();
            driver.FindElement(By.CssSelector("#swatch81")).Click();
            WebElement elem = (WebElement)driver.FindElement(By.CssSelector("#qty"));
            elem.Clear();
            elem.SendKeys("1");
            driver.FindElement(By.CssSelector("#product_addtocart_form > div.product-shop > div.product-options-bottom > div.add-to-cart > div.add-to-cart-buttons > button")).Click();
            driver.Quit();
        }

        static void RemoveProductFromCartTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            driver.FindElement(By.CssSelector("#nav > ol > li.level0.nav-5.parent > a")).Click();
            driver.FindElement(By.CssSelector("div.col-main > div.category-products > ul > li:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector("#swatch18")).Click();
            driver.FindElement(By.CssSelector("#swatch81")).Click();
            driver.FindElement(By.CssSelector("#product_addtocart_form > div.product-shop > div.product-options-bottom > div.add-to-cart > div.add-to-cart-buttons > button")).Click();
            driver.Navigate().Back();
            driver.Navigate().Back();
            driver.FindElement(By.CssSelector("div.col-main > div.category-products > ul > li:nth-child(3) > a")).Click();
            driver.FindElement(By.CssSelector("#swatch27")).Click();
            driver.FindElement(By.CssSelector("#swatch81")).Click();
            driver.FindElement(By.CssSelector("#product_addtocart_form > div.product-shop > div.product-options-bottom > div.add-to-cart > div.add-to-cart-buttons > button")).Click();
            driver.FindElement(By.CssSelector("#shopping-cart-table > tbody > tr.first.odd > td.a-center.product-cart-remove.last > a")).Click();
            driver.Quit();
        }

        static void SubmitReviewTest(IWebDriver driver)//revin
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            driver.FindElement(By.CssSelector("#nav > ol > li.level0.nav-5.parent > a")).Click();
            driver.FindElement(By.CssSelector("div.col-main > div.category-products > ul > li:nth-child(2)")).Click();


            //Click on any category
            //Select a random product
            //Press the Review section
            //Complete the all the required fields
            //Click the 'Submit Review' button"
            driver.Quit();
        }

        static void RegisterNewUserTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            //Click "Account" from right corner.
            //Click “Register” option from drop - down menu.
            //Fill in with valid data all the fields.
            //Click "Register" button.
            driver.Quit();
        }//revin

        static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);

            HomepageTest(driver);
            //AccountTest(driver);
            //LanguagesTest(driver);
            //SearchTest(driver);
            //NewProductListTest(driver);
            //NavigationTest(driver);
            //AddProductToCartTest(driver);
            //RemoveProductFromCartTest(driver);
            //SubmitReviewTest(driver);
            //RegisterNewUserTest(driver);

        }
    }
}
