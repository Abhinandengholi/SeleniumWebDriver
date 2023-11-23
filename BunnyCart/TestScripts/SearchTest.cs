using BunnyCart.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    internal class SearchTest:CoreCodes
    {
        [Test]
        [TestCase("Water poppy")]
        public void SearchProductAndAddToCart(string searchtext)
        {
           // CoreCodes.ScrollIntoView(driver, driver.FindElement(By.XPath("//div[@class='ftoolbar-sorter sorter'")));
            BCHomePage bchp = new(driver);
            var searchespage = bchp?.TypeSearchText(searchtext);
            Thread.Sleep(3000);
            Assert.That(searchtext.Contains(searchespage.GetFirstProductLink()));
            var productpage = searchespage?.ClickFirstProductLink();
            Thread.Sleep(3000);
            //Assert.That(searchtext.Equals(productpage?.GetProductUrl()), Is.True);
            string check=productpage.GetProductUrl();
            Assert.That(check.Contains("Water-poppy"));
            productpage.ClickInQtyLink();
            productpage.ClickAddToCartBtn();
            Thread.Sleep(3000);
        }
    }
}
