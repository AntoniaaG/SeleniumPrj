using NUnit.Framework;
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
            driver.FindElement(By.Id("select-language")).Click();
            driver.FindElement(By.CssSelector("#select-language > option:nth-child(2)")).Click();
            driver.Quit();
        }

        static void SearchTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            WebElement elem = (WebElement)driver.FindElement(By.Id("search"));
            elem.SendKeys("woman");
            driver.FindElement(By.XPath("//*[@id='search_mini_form']/div[1]/button")).Click();
            driver.Quit();

        }

        static void NewProductListTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            driver.FindElement(By.XPath("//*[@id='nav']/ol/li[1]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='top']/body/div/div/div[2]/div/div[2]/ul/li[1]/a")).Click();
            Console.WriteLine("Size of the list: "+ driver.FindElements(By.XPath("//*[@id='top']/body/div/div/div[2]/div/div[2]/div[2]/div[3]/ul/li")).Count());
            driver.Quit();
        }

        static void NavigationTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            driver.FindElement(By.XPath("//*[@id='nav']/ol/li[5]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='top']/body/div/div/div[2]/div/div[2]/div[2]/div[3]/ul/li[2]/a")).Click();
            driver.Quit();
        }

        static void AddProductToCartTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            driver.FindElement(By.XPath("//*[@id='nav']/ol/li[5]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='top']/body/div/div/div[2]/div/div[2]/div[2]/div[3]/ul/li[2]/a")).Click();
            driver.FindElement(By.Id("swatch18")).Click();
            driver.FindElement(By.Id("swatch81")).Click();
            WebElement elem = (WebElement)driver.FindElement(By.Id("qty"));
            elem.Clear();
            elem.SendKeys("1");
            driver.FindElement(By.XPath("//*[@id='product_addtocart_form']/div[3]/div[6]/div[2]/div[2]/button")).Click();
            driver.Quit();
        }

        static void RemoveProductFromCartTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            driver.FindElement(By.XPath("//*[@id='nav']/ol/li[5]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='top']/body/div/div/div[2]/div/div[2]/div[2]/div[3]/ul/li[2]/a")).Click();
            driver.FindElement(By.Id("swatch18")).Click();
            driver.FindElement(By.Id("swatch81")).Click();
            driver.FindElement(By.XPath("//*[@id='product_addtocart_form']/div[3]/div[6]/div[2]/div[2]/button")).Click();
            driver.Navigate().Back();
            driver.Navigate().Back();
            driver.FindElement(By.XPath("//*[@id='top']/body/div/div/div[2]/div/div[2]/div[2]/div[3]/ul/li[3]/a")).Click();
            driver.FindElement(By.Id("swatch27")).Click();
            driver.FindElement(By.Id("swatch81")).Click();
            driver.FindElement(By.XPath("//*[@id='product_addtocart_form']/div[3]/div[6]/div[2]/div[2]/button")).Click();
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div/div[2]/form/table/tbody/tr[1]/td[6]/a")).Click();
            driver.Quit();
        }

        static void SubmitReviewTest(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            //Click on any category
            //Select a random product
            //Press the Review section
            //Complete the all the required fields
            //Click the 'Submit Review' button"

            //IWebElement element = WebDriver.FindElement(By.Id("submit"));
            //element.Submit();
            driver.Quit();
        }//revin

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
