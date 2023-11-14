using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class AmazonHP
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()
        {

            driver = new ChromeDriver();                     //Initialising chrome driver
            driver.Url = "https://www.amazon.com/";         //Inputing Amazon website as Url
            driver.Manage().Window.Maximize();              //Maximize the webpage size
        }
        public void Titletest()
        {
            Thread.Sleep(2000); 
            Console.WriteLine("Title:" + driver.Title);
            Assert.That(driver.Title.Contains("amazon"));//checking whether the title contain the word amazon 
            Console.WriteLine("Title Test Passed");//if test passed it will write passed
        }
        public void OrganizTest()
        {
           
            Thread.Sleep(2000);
            Assert.That(driver.Url.Contains(".com"));//checking whether the Url contain .com
            Console.WriteLine("Organisation Test Passed");//if test passed it will write passed
        }
        public void Destruct()
        {
            driver.Close();//closing the current tab
        }

    }
}
