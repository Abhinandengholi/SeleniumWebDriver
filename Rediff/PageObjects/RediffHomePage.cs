using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Rediff.PageObjects
{
    internal class RediffHomePage
    {
        IWebDriver driver;  
        public RediffHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How =How.LinkText, Using = "Create Account")]
        public IWebElement? CreateAccountLink { get; set; }

        
        [FindsBy(How = How.LinkText, Using = "Sign in")]
        public IWebElement? SignInLink { get; set; }

        //Act
        public void CreateAccountLinkClick()
        {
            CreateAccountLink?.Click();
        }
       
        public  CreateAccountPage CreateAccountClick()
        {
            CreateAccountLink?.Click();
            return new CreateAccountPage(driver);
        }
        public void SignInLinkClick()
        {
            SignInLink?.Click();
        }
    }
}
