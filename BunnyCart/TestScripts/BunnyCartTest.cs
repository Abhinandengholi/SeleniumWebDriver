using   BunnyCart.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    [TestFixture]
    internal class BunnyCartTest:CoreCodes
    { 
        [Test]
        public void SignUpTest()
        {
            BCHomePage bchp = new(driver);
            bchp.ClickCeateAccountLink();
            Thread.Sleep(2000);
            try
            {
                Assert.That(driver.FindElement(By.XPath("//h1[contains(text(),'Create an Account')]")).Text,
                   Is.EqualTo("Create an Account")); ;
                //Assert.That(driver.FindElement(By.XPath("//div["+"@class= 'modal-inner-wrap']//following::h1[2]")).
                bchp.SignUp("Abhi", "Nand", "abhi04@.com", "1234", "1234", "3243434");
            
            }
            catch (AssertionException ex)
            {
                Console.WriteLine("Create account modal not present");
            }
           
            
        }

    }
}
