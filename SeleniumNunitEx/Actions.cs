using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitEx
{
    [TestFixture]
    internal class Actions : CoreCodes
    {
        [Test]
        public void HomeLinktest()
        {
            IWebElement homelink = driver.FindElement(By.LinkText("Home"));
            IWebElement tdhomelink = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody/tr/td[1]/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[1]/td[1]"));
            
            Actions actions=new Actions(driver);
            Action mouseOverHomeLink = actions.movetoElement().build();
        }
    }
       
}
