using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNunit
{
    internal class flipkart:CoreCodes
    {
        [Test]
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
            //IWebElement searchbutton = driver.FindElement(By.ClassName("_2iLD__"));       //Name("btnK"));
            //searchbutton.Click();
          
           
        }
    }
}
