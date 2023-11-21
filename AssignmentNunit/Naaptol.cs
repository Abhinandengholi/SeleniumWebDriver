using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNunit
{
    internal class Naaptol : CoreCodes
    {

        [Test]
        [Order(0)]

        public void searchtest()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement Searchinput = fluentWait.Until(d => d.FindElement(By.XPath("//input[@id='header_search_text']")));
            Searchinput.SendKeys("eyewear");
            Searchinput.SendKeys(Keys.Enter);

        }
        [Test]
        [Order(1)]
        [TestCaseSource(nameof(Productdata))]
        public void AddToCart(string pId)
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//div[@id='productItem" + pId + "']")));
            IWebElement Search5 = fluentWait.Until(d => d.FindElement(By.XPath("//div[@id='productItem" + pId + "']")));
            Search5.Click();
            List<string> lstWindow = driver.WindowHandles.ToList();
            foreach (var handle in lstWindow)
            {
                driver.SwitchTo().Window(handle);
                Thread.Sleep(3000);
            }
           
            IWebElement clickbutton = fluentWait.Until(d => d.FindElement(By.XPath("//a[text()='Black-2.50']")));
            clickbutton.Click();
            IWebElement cart = fluentWait.Until(d => d.FindElement(By.XPath("//a[@class='red_button icon chat']")));
            cart.Click();
            Thread.Sleep(2000);

        }
        static object[] Productdata()
        {
            return new object[]
            {
             new object[] { "5" }

            };

        }

       [Test]
        [Order(2)]
        public void ViewCart()
        {
            string title = "https://www.naaptol.com/eyewear/reading-glasses-with-led-lights-lrg4/p/12612074.html";
            Assert.AreEqual(driver.FindElement(By.XPath("//a[contains(text(),'LRG4')]")).GetAttribute("href"), title);
        }
    }
}
