using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Edge;

namespace SeleniumEx
{
    internal class GHPTests
    {
        IWebDriver? driver;
       // public void InitializeEdge()
        //{

        //    // driver = new ChromeDriver();
        //    driver = new EdgeDriver();
        //    driver.Url = "https://www.google.com/";
        //}
        public void InitializeEdgeDriver()
        {

            driver = new EdgeDriver();
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();
        }
        public void InitializeChromeDriver()
        {

            driver = new ChromeDriver();
         
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();
        }
        public void Titletest()
        {
            Thread.Sleep(2000); //dont use this, means clean coding
            //string title = driver.Title;
            Console.WriteLine("Title:"+driver.Title);
           // Console.WriteLine(title.Length);
            Console.WriteLine("Title length:"+driver.Title.Length);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Test Passed");
        }
        public void PageSourceandURLTest()
        {
            // Console.WriteLine("PageSource: "+driver.PageSource);
           // Console.WriteLine("PS Length:" + driver.PageSource.Length);
           // Console.WriteLine(driver.Url);
            Assert.AreEqual("https://www.google.com/", driver.Url);
            Console.WriteLine("URL-Test Passed");

        }
        public void GStest()
        {
            IWebElement Searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
            Searchinputtextbox.SendKeys("hp laptop");
            Thread.Sleep(3000);
            IWebElement searchbutton = driver.FindElement(By.ClassName("gNO89b"));                        //Name("btnK"));
            searchbutton.Click();
            Assert.AreEqual("hp laptop - Google Search",driver.Title);
            Console.WriteLine("GS-Test passed");
        }
        public void GmailLinkTest() 
        
        {
            driver.Navigate().Back();
            //driver.FindElement(By.LinkText("Gmail")).Click();
                driver.FindElement(By.PartialLinkText("ma")).Click();

            Thread.Sleep(3000);
        //    //string title=driver.Title;
           Assert.That(driver.Title.Contains("Gmail"));
            //Assert.That(driver.Url.Contains("gmail"));
           Console.WriteLine("Gmail link text test passed");

        }
        public void ImageLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.PartialLinkText("mag")).Click();

                Thread.Sleep(3000);
               
               Assert.That(driver.Title.Contains("Images"));
               Console.WriteLine("Image link  test passed");

        }
        public void LocalizationTest()
        {
            driver.Navigate().Back();
            string loc = driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;

            Thread.Sleep(3000);

            Assert.That(loc.Equals("India"));
            Console.WriteLine("localization test passed");

        }
        public void GAppYoutubeTest()
        {
            
            driver.FindElement(By.ClassName("gb_d")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector(
            Thread.Sleep(3000); 
            Assert.That(driver.Title.Contains("Youtube"));
            Console.WriteLine("Youtube test passed");

        }


        public void Destruct()
        {
            driver.Close();
        }
    }
}