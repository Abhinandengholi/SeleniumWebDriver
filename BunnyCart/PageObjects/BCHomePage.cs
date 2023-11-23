using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class BCHomePage
    {

        IWebDriver driver;
        public BCHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));//if  the driver is null  guexception thrown
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.Id, Using = "search")]
        [CacheLookup]//store the particular locator inside the cache memory
        public IWebElement? SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Create an Account']")]
        [CacheLookup]
        private IWebElement? CreateAccountLink { get; set; }

        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement? FirstNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement? LastNameInput { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement? EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement? PasswordInput { get; set; }

        [FindsBy(How = How.Name, Using = "password_confirmation")]
        private IWebElement? ConfirmPasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "mobilenumber")]
        private IWebElement? MobileNumberInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@title='Create an Account']")]
        private IWebElement? SignUpButton { get; set; }

        //Act
        public void ClickCeateAccountLink()
        {
            CreateAccountLink?.Click();
        }
        public void SignUp(string firstname, string lastname, string email, string pwd, string confirmpwd, string mobilenumber)
        {
            IWebElement modal = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
           .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class='modal-inner-wrap'])[position()=2]")));

            FirstNameInput?.SendKeys(firstname);
            LastNameInput?.SendKeys(lastname);
            EmailInput?.SendKeys(email);

            CoreCodes.ScrollIntoView(driver, modal.FindElement(By.Id("password")));
            PasswordInput?.SendKeys(pwd);
            ConfirmPasswordInput?.SendKeys(confirmpwd);

            CoreCodes.ScrollIntoView(driver, modal.FindElement(By.Id("mobilenumber")));
            MobileNumberInput?.SendKeys(mobilenumber);
            Thread.Sleep(1000);
            SignUpButton?.Click();
        }

        //static void ScrollIntoView(IWebDriver driver, IWebElement element)
        //{
        //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        //    js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        //}
        public SearchResultPage TypeSearchText(string searchtext)
        {
            if (SearchInput == null)
            {
                throw new NoSuchElementException(nameof(SearchInput));
            }
            SearchInput.SendKeys(searchtext);
            SearchInput.SendKeys(Keys.Enter);
            return new SearchResultPage(driver);
        }
    }
}
