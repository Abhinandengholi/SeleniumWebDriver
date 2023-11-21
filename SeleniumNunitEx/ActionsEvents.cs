using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitEx
{
    [TestFixture]
    internal class ActionsEvents : CoreCodes
    {
        [Test]
        public void HomeLinktest()
        {
            IWebElement homelink = driver.FindElement(By.LinkText("Home"));
            IWebElement tdhomelink = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody/tr/td[1]/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[1]"));
            Actions actions =new Actions(driver);
            Action mouseOverAction = () => actions.MoveToElement(homelink).Build().Perform();
            Console.WriteLine("Before:" + tdhomelink.GetCssValue("background-color"));
            mouseOverAction.Invoke();
            Console.WriteLine("After:" + tdhomelink.GetCssValue("background-color"));
            Thread.Sleep(1000);
        }
        [Test]
        public void MultipleActionsTest()
        {
            driver.Navigate().GoToUrl("https://in.linkedin.com/");
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(5);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";

            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
            Actions actions = new Actions(driver);
            Action uppercaseInput = () => actions
            .KeyDown(Keys.Shift)
            .SendKeys(emailInput,"hello")
            .KeyUp(Keys.Shift)
            .Build()
            .Perform();    
            uppercaseInput.Invoke();
            Console.WriteLine("text is:" + emailInput.GetAttribute("value"));
            Thread.Sleep(2000);

        }
    }
       
}
