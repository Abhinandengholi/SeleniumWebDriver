using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitEx
{
    [TestFixture]
    internal class LinkedInTest : CoreCodes
    {
        [Test, Category("Regression Testing"), Author("ABHI", "abhi04@gmail.com")]
        [Description("check for valid login")]

       
        public void LoginTest()
        {

            //driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(3);//implicit
            //IWebElement emailInput = driver.FindElement(By.Id("session_key"));
            //IWebElement passwordInput=driver.FindElement(By.Id("session_password"));
            //explicit
            //WebDriverWait wait =new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            //IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));//explicit
            // IWebElement passwordInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));
            //IWebElement emailInput = wait.Until(driv=>driv.FindElement(By.Id("session_key")));
            //IWebElement passwordInput = wait.Until(d => d.FindElement(By.Id("session_password")));
            //fluent wait
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(5);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));

            emailInput.SendKeys("Aswd@ddd");
            passwordInput.SendKeys("234343");


        }

        [Test]
         [Author("ABHI", "abhi04@gmail.com")]
         [Description("check for invalid login")]
         [Category("Smoke Testing")]
         public void LoginTestWithInvalidCredential()
         {
             //fluent wait
             DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
             fluentWait.Timeout = TimeSpan.FromSeconds(5);
             fluentWait.PollingInterval = TimeSpan.FromMilliseconds(5);
             fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
             fluentWait.Message = "element not found";
             IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
             IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));

             emailInput.SendKeys("Aswd@dd");
             passwordInput.SendKeys("234");
             Thread.Sleep(3000);
             ClearForm(emailInput);
             ClearForm(passwordInput);
             emailInput.SendKeys("Bs12@ddd");
             passwordInput.SendKeys("456");
             Thread.Sleep(3000);
             ClearForm(emailInput);
             ClearForm(passwordInput);
             emailInput.SendKeys("Cs23@ddd");
             passwordInput.SendKeys("567");
             Thread.Sleep(3000);
             ClearForm(emailInput);
             ClearForm(passwordInput);
             Thread.Sleep(3000);


         }
         void ClearForm(IWebElement element)
         {
             element.Clear();
         }

        /* [Test]
         [Author("Franks", "frank07@gmail.com")]
         [Description("check for invalid login")]
         [Category("Regression Testing")]
         [TestCase("Aswd@dd","234")]
         [TestCase("Bs12@ddd", "456")]
         [TestCase("Cs23@ddd", "567")]
         public void LoginTestWithInvalidCred(string email,string pwd)
         {
             DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
             fluentWait.Timeout = TimeSpan.FromSeconds(5);
             fluentWait.PollingInterval = TimeSpan.FromMilliseconds(5);
             fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
             fluentWait.Message = "element not found";

             IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
             IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));
             emailInput.SendKeys(email);
             passwordInput.SendKeys(pwd);
             Thread.Sleep(3000);
             ClearForm(emailInput);
             ClearForm(passwordInput);
             Thread.Sleep(3000);
         }
         void ClearForm(IWebElement element)
         {
             element.Clear();
         }*/
        [Test]
        
        [Author("Franks", "frank07@gmail.com")]
        [Description("check for invalid login")]
        [Category("Regression Testing")]
        [TestCaseSource(nameof(InvalidLoginData))]
        public void LoginTestWithInvalidCred(string email, string pwd)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(5);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";

            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));
            emailInput.SendKeys(email);
            passwordInput.SendKeys(pwd);
            TakeScreenshot();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//button[@type='submit']")));
            Thread.Sleep(3000); 
            js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//button[@type='submit']")));
            
            ClearForm(emailInput);
            ClearForm(passwordInput);

            void ClearForm(IWebElement element)
            {
                element.Clear();

            }
        }
        static object[] InvalidLoginData()
            {
            return new object[]
            {
             new object[] {"Aswd@dd","234"},
             new object[] {"Bs12@ddd", "456" },
             new object[] {"Cs23@ddd", "567" }
            };
        }
      
    }
}