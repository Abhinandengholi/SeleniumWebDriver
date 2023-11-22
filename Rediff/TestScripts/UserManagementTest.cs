using Rediff.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.TestScripts
{
    [TestFixture]
    internal class UserManagementTest:CoreCodes
    {
        //Asserts
        [Test, Order(1),Category("Smoke Test")]
        public void CreateAccountLinkTest()
        {
           var homepage= new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            homepage.CreateAccountLinkClick();
            Assert.That(driver.Url.Contains("register"));
        }
        [Test, Order(2), Category("Smoke Test")]
        public void SingInLinkTest()
        {
            var homepage = new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            homepage.SignInLinkClick();
            Assert.That(driver.Url.Contains("login"));
        }
        [Test, Order(1), Category("Regression Test")]
        public void CreateAcccountTest()
        {
            var homepage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            }
            homepage.CreateAccountClick();
            Thread.Sleep(2000);
        }

    }
}
