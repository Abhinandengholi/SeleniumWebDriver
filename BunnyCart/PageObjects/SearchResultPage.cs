using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class SearchResultPage
    {

        IWebDriver driver;
        public SearchResultPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));//if  the driver is null  guexception thrown
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement? FirstProductlink { get;}
        public string? FirstProductLink()
        {
            return FirstProductlink?.Text;
        }
        public ProductPage ClickFirstProductLink()
        {
            FirstProductlink?.Click();
            return new ProductPage(driver);

        }
    }
}
