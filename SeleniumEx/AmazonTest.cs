using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumEx
{
    internal class AmazonTest
    {
        IWebDriver? driver;
        
        //public void InitializeEdgeDriver()
        //{

        //    driver = new EdgeDriver();
        //    driver.Url = "https://www.amazon.com/";
        //    driver.Manage().Window.Maximize();
        //}
        public void InitializeChromeDriver()
        {

            driver = new ChromeDriver();

            driver.Url = "https://www.amazon.com/";
            driver.Manage().Window.Maximize();
        }
        public void Titletest()
        {
            Thread.Sleep(2000); 
            Console.WriteLine("Title:" + driver.Title);

            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Title Test Passed");
        }
        public void LogClickTest()
        { driver.FindElement(By.Id("nav-logo-sprites")).Click();
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Logclick test passed");
        }
        public void SearchProductTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobiles");
            Thread.Sleep(4000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Assert.That(("Amazon.com : mobiles".Equals(driver.Title))&&(driver.Url.Contains("mobiles")));
            Console.WriteLine("Search test passed");
        }
        public void ReloadHomePage()
        {

            driver.Navigate().GoToUrl("https://www.amazon.com");
            Thread.Sleep(3000);
            Console.WriteLine("reload passed");
        }
        public void TodaysDealsTest()
        {

            IWebElement todaysdeals =driver.FindElement(By.LinkText("Today's Deals"));
            if(todaysdeals == null)
            { 
                throw new NoSuchElementException("Today's Deal Link not present");
            }
            todaysdeals.Click();
            Thread.Sleep(4000);
            Assert.That(driver.FindElement(By.TagName("h1")).Text.Equals("Today's Deals"));
            Console.WriteLine("Today's deal test passed");
        }
        public void SignInAccListTest()
        {
            IWebElement hellosignin = driver.FindElement(By.Id("nav-link-accountList-nav-line-1"));
            if(hellosignin == null)
            {
                throw new NoSuchElementException("Hello,Signin is not present");
            }
            IWebElement accountandlists = driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]/span"));
            if(accountandlists == null)
            {
                throw new NoSuchElementException("Hello,Account and list is not present");
            }
            Assert.That(hellosignin.Text.Equals("Hello, sign in"));
            Console.WriteLine("Hello sign is present - pass");
            //Assert.That(accountandlists.Text.Equals("Account & Lists"));
            Console.WriteLine("Account and list is present - pass");
        }
        public void SearchAndFilterProductByBrandTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobile phones");
            Thread.Sleep(4000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            //Assert.That(("Amazon.com : mobiles".Equals(driver.Title)) && (driver.Url.Contains("mobiles")));
            IWebElement mototcheckbox = driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/i"));                           
                //(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/input"));
            Thread.Sleep(3000);
            mototcheckbox.Click();
            Thread.Sleep(3000);
            Assert.True(mototcheckbox.Selected);
            Console.WriteLine("Motorola is selected successfully");
            driver.FindElement(By.ClassName("a-expander-prompt")).Click();
            IWebElement applecheckbox = driver.FindElement(By.XPath("//*[@id=\"p_89/Apple\"]/span/a/div/label/i"));
            Thread.Sleep(3000); 
            applecheckbox.Click();
            Assert.True(applecheckbox.Selected);
            Console.WriteLine("Apple is selected successfully");
        }
    
        public void Destruct()
        {
            driver.Close();
        }
    }
}

