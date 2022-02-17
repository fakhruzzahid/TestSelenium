using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;
using System.Threading;
using Xunit;

namespace TestSelenium
{
    class Case
    {
        public static string RandomChar(int length)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
                     .ToCharArray();
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                char c = chars[random.Next(chars.Length)];
                sb.Append(c);
            }
            String randomString = sb.ToString();
            return randomString;
        }

        static void Main(string[] args)
        {
            //create the reference for the browser  
            IWebDriver driver = new ChromeDriver(@"C:\Users\Leo\Documents\Test Kerja\Test Selenium");

            // ==== Case 1 ====

            // navigate to URL Test Case 1 
            driver.Navigate().GoToUrl("http://automationpractice.com/");
            Thread.Sleep(2000);

            // Check Element Sign in Exist
            IWebElement checkDasboard = driver.FindElement(By.ClassName("login"));
            Assert.True(checkDasboard.Text.Contains("Sign in"));

            Console.WriteLine("--- Register Success New Account ---");

            // Click Button Sign in
            driver.FindElement(By.ClassName("login")).Click();
            Thread.Sleep(2000);

            //Generate Random String for Email
            string email = RandomChar(12);

            // Input Form Create an Account
            driver.FindElement(By.Id("email_create")).SendKeys(email + "@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            Thread.Sleep(3000);

            // Check Page Register
            IWebElement checkRegisterPage = driver.FindElement(By.Id("center_column"));
            Assert.True(checkRegisterPage.Enabled);

            // Input Form Register
            driver.FindElement(By.Id("id_gender1")).Click();

            driver.FindElement(By.Id("customer_firstname")).SendKeys("Fakhruzzahid");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Wahdah");

            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(email + "@gmail.com");
            driver.FindElement(By.Id("passwd")).SendKeys("password123");
            driver.FindElement(By.Id("firstname")).SendKeys("Fakhruzzahid");
            driver.FindElement(By.Id("lastname")).SendKeys("Wahdah");
            driver.FindElement(By.Id("address1")).SendKeys("Jakarta Barat");
            driver.FindElement(By.Id("city")).SendKeys("Jakarta Barat");

            IWebElement selectState = driver.FindElement(By.XPath("//*[@id='id_state']/option[34]"));
            selectState.Click();
            Thread.Sleep(2000);

            driver.FindElement(By.Id("postcode")).SendKeys("11510");

            IWebElement selectCountry = driver.FindElement(By.XPath("//*[@id='id_country']/option[2]"));
            selectCountry.Click();
            Thread.Sleep(2000);

            driver.FindElement(By.Id("phone_mobile")).SendKeys("081335990344");

            driver.FindElement(By.Id("alias")).Clear();
            driver.FindElement(By.Id("alias")).SendKeys("My address");

            //Click Button Register
            driver.FindElement(By.Id("submitAccount")).Click();
            Thread.Sleep(2000);

            //Check Success Register
            IWebElement checkSuccess = driver.FindElement(By.ClassName("account"));
            Assert.True(checkSuccess.Text.Contains("Fakhruzzahid Wahdah"));

            Console.WriteLine("Success Create Account");

            //Sign Out
            driver.FindElement(By.ClassName("logout")).Click();


            Console.WriteLine("--- Sign In New Account ---");

            //Input Username and Password
            driver.FindElement(By.Id("email")).SendKeys(email+"@gmail.com");
            driver.FindElement(By.Id("passwd")).SendKeys("password123");

            // Click Button Login
            driver.FindElement(By.Id("SubmitLogin")).Click();

            //Check Success Login
            IWebElement loginsuccess = driver.FindElement(By.ClassName("account"));
            Assert.True(loginsuccess.Text.Contains("Fakhruzzahid Wahdah"));

            Console.WriteLine("Success Login");

            driver.Close();
            Console.WriteLine("Test End and Success");
        }

    }
}
