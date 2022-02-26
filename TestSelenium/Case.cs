using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace TestSelenium
{
    class Case
    {

        static void Main(string[] args)
        {
            //create the reference for the browser  
            IWebDriver driver = new ChromeDriver(@"C:\Users\Leo\Documents\Test Kerja\Test Selenium");
            WebDriverWait waitelement = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            // ==== Case 1 ====

            // navigate to URL
            driver.Navigate().GoToUrl("https://www.ebay.com/");
            Thread.Sleep(2000);

            Console.WriteLine("--- Skenario 1 ---");

            //CLick Search Category
            driver.FindElement(By.Id("gh-btn")).Click();
            driver.FindElement(By.XPath("//*[@id='wrapper']/div[1]/div/div/div[2]/div[1]/ul/li[7]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='electronics']/div/div[2]/div/ul/li[2]/a")).Click();
            Thread.Sleep(3000);

            //Choose Filter

            waitelement.Until(ExpectedConditions.ElementExists(By.ClassName("container")));

            IWebElement allFilter = driver.FindElement(By.ClassName("container"));
            allFilter.FindElement(By.XPath("//*[. = 'All Filters']")).Click();

            //Filter Screen
            waitelement.Until(ExpectedConditions.ElementExists(By.ClassName("x-overlay__container")));
            IWebElement filterScreen = driver.FindElement(By.ClassName("x-overlay__container"));
            filterScreen.FindElement(By.XPath("//*[. = 'Screen Size']")).Click();

            waitelement.Until(ExpectedConditions.ElementExists(By.XPath("//*[. = '4.0 - 4.4 in']")));
            IWebElement screenInput = driver.FindElement(By.ClassName("x-overlay__sub-panel"));
            screenInput.FindElement(By.XPath("//*[. = '4.0 - 4.4 in']")).Click();

            //Filter Price 
            waitelement.Until(ExpectedConditions.ElementExists(By.XPath("//*[@data-aspecttitle = 'price']")));
            IWebElement filterprice = driver.FindElement(By.ClassName("x-overlay__container"));
            filterprice.FindElement(By.XPath("//*[@data-aspecttitle = 'price']")).Click();

            waitelement.Until(ExpectedConditions.ElementExists(By.XPath("//*[@aria-label='Minimum Value, US Dollar']")));
            driver.FindElement(By.XPath("//*[@aria-label='Minimum Value, US Dollar']")).SendKeys("1000000");
            driver.FindElement(By.XPath("//*[@aria-label='Maximum Value, US Dollar']")).SendKeys("3000000");

            //Filter Location 
            waitelement.Until(ExpectedConditions.ElementExists(By.XPath("//*[@data-aspecttitle='location']")));
            IWebElement filterLocation = driver.FindElement(By.ClassName("x-overlay__container"));
            filterLocation.FindElement(By.XPath("//*[@data-aspecttitle='location']")).Click();

            waitelement.Until(ExpectedConditions.ElementExists(By.XPath("//*[@data-value='US Only']")));
            driver.FindElement(By.XPath("//*[@data-value='US Only']")).Click();
            Thread.Sleep(3000);

            //Click Button FilterApply
            driver.FindElement(By.XPath("//*[@aria-label='Apply']")).Click();

            //Check Filter is True

            waitelement.Until(ExpectedConditions.ElementExists(By.XPath("//*[. = '3 filters applied']")));
            Thread.Sleep(3000);

            
            // ==== Case 2 ====

            // navigate to URL
            driver.Navigate().GoToUrl("https://www.ebay.com/");
            Thread.Sleep(2000);

            Console.WriteLine("--- Skenario 2 ---");

            //Search
            waitelement.Until(ExpectedConditions.ElementExists(By.XPath("//*[@aria-label='Search for anything']")));
            driver.FindElement(By.XPath("//*[@aria-label='Search for anything']")).SendKeys("Macbook");

            waitelement.Until(ExpectedConditions.ElementExists(By.XPath("//*[@aria-label='Select a category for search']")));
            IWebElement selectSearch = driver.FindElement(By.XPath("//*[@aria-label='Select a category for search']"));
            selectSearch.FindElement(By.XPath("//*[@value='58058']")).Click();
            driver.FindElement(By.XPath("//*[@value='Search']")).Click();

            //Verify Search
            waitelement.Until(ExpectedConditions.ElementExists(By.XPath("//*[. = 'macbook']")));
            IWebElement checkSearch = driver.FindElement(By.XPath("//*[. = 'macbook']"));
            Assert.True(checkSearch.Text.Contains("macbook"));

            Console.WriteLine("Test End and Success");
            driver.Close();
            
        }

    }
}
