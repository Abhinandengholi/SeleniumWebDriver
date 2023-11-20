using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SeleniumNunitEx
{
    [TestFixture]
    internal class Elements : CoreCodes
    {
        [Ignore(" ")]
        [Test]
        public void TestElements()
        {
            Thread.Sleep(1000);
            //IWebElement elements=driver.FindElement(By.XPath("//h5[text()='Elements']//parent::div"));
            //elements.Click();
            IWebElement cbmenu = driver.FindElement(By.XPath("//span[text()='Check Box']//parent::li"));
            cbmenu.Click();
            List<IWebElement> expandcollapse = driver.FindElements(By.ClassName("rct-collapse rct-collapse-btn")).ToList();
            foreach (var item in expandcollapse)
            {
                item.Click();
            }
            IWebElement commandscheckbox = driver.FindElement(By.XPath("//span[text()='Commands']"));
            commandscheckbox.Click();
            Assert.True(driver.FindElement(By.XPath("//input[contains(@id,'commands')]")).Selected);
        }
        [Ignore(" ")]
        [Test]
        public void TestFormElements()
        {
            //Thread.Sleep(2000);
            IWebElement firstNameField = driver.FindElement(By.Id("firstName"));
            firstNameField.SendKeys("John");
            Thread.Sleep(2000);
            IWebElement lastNameField = driver.FindElement(By.Id("lastName"));
            lastNameField.SendKeys("Marshell");
            Thread.Sleep(2000);

            IWebElement emailField = driver.FindElement(By.XPath("//input[@id='userEmail']"));
            emailField.SendKeys("mailid@gmail.com");
            Thread.Sleep(2000);
            IWebElement genderRadio = driver.FindElement(By.XPath("//input[@id='gender-radio-1']//following::label"));
            genderRadio.Click();
            Thread.Sleep(2000);
            IWebElement mobileNumberField = driver.FindElement(By.Id("userNumber"));
            mobileNumberField.SendKeys("12345676");
            Thread.Sleep(2000);

            IWebElement dobField = driver.FindElement(By.Id("dateOfBirthInput"));
            dobField.Click();
            Thread.Sleep(2000);

            IWebElement dobMonth = driver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));
            SelectElement selectmonth = new SelectElement(dobMonth);
            selectmonth.SelectByIndex(1);
            Thread.Sleep(2000);

            IWebElement dobYear = driver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));
            SelectElement selectyear = new SelectElement(dobYear);
            selectyear.SelectByText("1998");
            Thread.Sleep(2000);
            IWebElement dobDay = driver.FindElement(By.XPath("//div[@class='react-datepicker__day react-datepicker__day--008 react-datepicker__day--weekend']"));
            dobDay.Click();
            Thread.Sleep(2000);
            IWebElement subjectsField = driver.FindElement(By.Id("subjectsInput"));
            subjectsField.SendKeys("Maths");
            subjectsField.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            subjectsField.SendKeys("Physics");
            subjectsField.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            IWebElement hobb = driver.FindElement(By.XPath("//label[text()='Sports']"));
            //IWebElement hobb = driver.FindElement(By.XPath("//input[@id='hobbies-checkbox-3']//following::label"));
            hobb.Click();
            Thread.Sleep(2000);

            IWebElement pictureField = driver.FindElement(By.Id("uploadPicture"));
            pictureField.SendKeys("C:\\Users\\Administrator\\Downloads\\ironman.jpg");
            Thread.Sleep(2000);
            IWebElement currentaddresField = driver.FindElement(By.Id("currentAddress"));
            currentaddresField.SendKeys("123 street,city,country");
            Thread.Sleep(2000);


        }
        [Ignore("")]
        [Test]
        public void TestWindow()
        {
            driver.Url = "http://demoqa.com/browser-windows";
            string parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parent window's handle->"+parentWindowHandle);
            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));
            for(var i= 0; i < 2; i++)
            {
                clickElement.Click();
                Thread.Sleep(3000);
            }
            List<string>lstWindow=driver.WindowHandles.ToList();
            //string lastWindowHandle = "";
            foreach(var handle in lstWindow)
            {
                Console.WriteLine("Switching to window->" + handle);
                driver.SwitchTo().Window(handle);
                Thread.Sleep(2000);
                Console.WriteLine("Navigate to google.com");
                driver.Navigate().GoToUrl("https://google.com");
                Thread.Sleep(2000);
                //lastWindowHandle = handle;

            }
            driver.SwitchTo().Window(parentWindowHandle);
            driver.Quit();

        }
        [Ignore(" ")]
        [Test]
        public void TestAlerts()
        {
            driver.Url = "https://demoqa.com/alerts";
            IWebElement element = driver.FindElement(By.Id("alertButton"));
            Thread.Sleep(3000);
            driver.ExecuteJavaScript("arguments[0].click()", element);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()",element);
            IAlert simpleAlert = driver.SwitchTo().Alert();
            string alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is"+alertText);
            Thread.Sleep(5000);
            simpleAlert.Accept();
            element = driver.FindElement(By.Id("confirmButton"));
            Thread.Sleep(5000);
            element.Click();
            IAlert confirmationAlert = driver.SwitchTo().Alert();
            string alertTxt=confirmationAlert.Text;
            Console.WriteLine("Alert is:" + alertTxt);
            Thread.Sleep(5000);
            confirmationAlert.Dismiss();

            element = driver.FindElement(By.Id("promtButton"));
            Thread.Sleep(5000);
            element.Click();
            IAlert promptAlert = driver.SwitchTo().Alert();

            promptAlert.SendKeys("Accepting the alert");
            Thread.Sleep(5000);
            alertText = promptAlert.Text;
            Console.WriteLine("Alert text is:" + alertTxt);
            promptAlert.Accept();

        }
    }
}
