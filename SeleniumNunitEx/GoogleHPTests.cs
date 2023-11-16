using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitEx
{
    [TestFixture]
    internal class GoogleHPTests
    {
        [Test]
        public void Titletest()
        {
            Thread.Sleep(2000); 
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Test Passed");
        }
    }
}
