using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            foreach(var item in expandcollapse)
            {
                item.Click();
            }
            IWebElement commandscheckbox = driver.FindElement(By.XPath("//span[text()='Commands']"));
            commandscheckbox.Click();
            Assert.True(driver.FindElement(By.XPath("//input[contains(@id,'commands')]")).Selected);
        }
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
           SelectElement selectmonth= new SelectElement(dobMonth);
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
    }
}
