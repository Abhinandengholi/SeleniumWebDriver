using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNunit
{
    internal class Flipkart:CoreCodes
    {
        [Test]
        [Order(0)]
        public void searchtest()
        {
           Thread.Sleep(3000);
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement Searchinput= driver.FindElement(By.XPath("//input[contains(@class,'Pke_EE')]"));
            Searchinput.SendKeys("hp laptop");
            Searchinput.SendKeys(Keys.Enter);
            
        }
        [Test]
        [Order(1)]
        public void AddToCart()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(5);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement Input = fluentWait.Until(d => d.FindElement(By.XPath("//div[@class='_2kHMtA'][1]")));
            Input.Click();
            Thread.Sleep(2000);
            //List<string> lstWindow = driver.WindowHandles.ToList();

            //foreach (var handle in lstWindow)
            //{
            //    driver.SwitchTo().Window(handle);

            //}

            IWebElement Input1 = fluentWait.Until(d => d.FindElement(By.XPath("//button[@class='_2KpZ6l _2U9uOA _3v1-ww']")));
            //IWebElement Input2 = fluentWait.Until(d => d.FindElement(By.XPath("//button[@class='_2KpZ6l _2U9uOA ihZ75k _3AWRsL']")));
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollintoview(true)", Input2);
            Input1.Click();
            
        }
    }
}
