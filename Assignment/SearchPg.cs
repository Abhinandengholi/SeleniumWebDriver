using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment
{
    internal class SearchPg
    {

        IWebDriver? driver;
        public void CheckingPage()
        {

            driver = new ChromeDriver();                     //Initialising chrome driver
            driver.Url = "https://www.Google.com/";         //Inputing Amazon website as Url
            driver.Manage().Window.Maximize();              //Maximize the webpage size
            driver.Navigate().GoToUrl("https://www.yahoo.com/");//navigate yahoo home page
            Thread.Sleep(5000);
            driver.Navigate().Back();//going back to google home page
            Thread.Sleep(5000);
            driver.Navigate().Forward();//going to yahoo home page
            Thread.Sleep(5000);
            driver.Navigate().Back();//going back to google home page
            Thread.Sleep(5000);
            IWebElement Searchinputtextbox = driver.FindElement(By.Id("APjFqb"));           //selecting the input search box
                Searchinputtextbox.SendKeys("what's new for Diwali 2023?");                 //enter the search term inside the search box
                Thread.Sleep(2000);
                IWebElement searchbutton = driver.FindElement(By.ClassName("gNO89b"));       //getting google search button                 
                searchbutton.Click();                                                          //clicking the google search button
                Assert.That(driver.Title.Contains("what's new for Diwali 2023? - Google Search"));//checking the page is loaded properly
                Console.WriteLine("Page change-Test passed");                   //if the page is loaded properly it will show
            driver.Navigate().Refresh();                                //refresh page
            driver.Close();

            
        }
    }
}
