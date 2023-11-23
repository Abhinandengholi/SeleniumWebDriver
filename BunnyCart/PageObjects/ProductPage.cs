using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class ProductPage
    {
        IWebDriver driver;
        public ProductPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));//if  the driver is null  guexception thrown
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.XPath, Using = "//h1[@class='page-title']")]
        private IWebElement? productTitleLabel { get; }

        [FindsBy(How = How.ClassName, Using = "qty-inc")]
        private IWebElement? InQtyLink { get; set; }

        [FindsBy(How = How.Id, Using = "product-addtocart-button")]
        private IWebElement?    AddToCartBtn { get; set; }

        //Act
        //public string? GetProductTitleLabel()
        //{
        //    return productTitleLabel?.Text;
        //}
        public string? GetProductUrl()
        {
            string url = driver.Url;
            return url;
        }
        public void ClickInQtyLink()
        {
            InQtyLink?.Click();

        }
        public void ClickAddToCartBtn()
        {
           AddToCartBtn?.Click();
        }
    }
}
