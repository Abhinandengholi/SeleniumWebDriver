using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNunit.PageObjects
{
    internal class Product
    {
        IWebDriver driver;
        public Product(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.XPath, Using = "//a[text()='Black-2.50']")]
         public IWebElement? SizeClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='red_button icon chat']")]
        public IWebElement? AddToCart { get; set; }
        //Act
        public void  SizecheckClick()
        {
            SizeClick?.Click();
           
        }
        public void ClickAddCart()
        {
            AddToCart?.Click();

        }
    }
}

