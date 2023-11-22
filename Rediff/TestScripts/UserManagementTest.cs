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
        /*[Test, Order(1),Category("Smoke Test")]
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
        }*/
        [Test, Order(1), Category("Regression Test")]
        public void CreateAcccountTest()
        {
            var homepage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            }
            var createaccountpage= homepage.CreateAccountClick();
            Thread.Sleep(2000);
            createaccountpage.TypeFullName("Abhi");
            createaccountpage.TypeRediffMail("Abhi04@.com");
            createaccountpage.CheckAvailibilitybtn();
            Thread.Sleep(2000);
            createaccountpage.ClickCreateMyAccountbtn();
        }
        [Test, Order(1), Category("Regression Test")]
        public void SignInFuncTest()
        {
            var homepage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            }
            var signinpage = homepage.SignInLinkClick();
            Thread.Sleep(2000);
            signinpage.TypeUserName("User");
            signinpage.TypePassword("Password");
            signinpage.ClickRememberMeCheckbox();
            Assert.False(signinpage?.RememberMeCheckbox?.Selected);
            Thread.Sleep(2000);
            signinpage?.ClickSignIn();
        }

    }
}
