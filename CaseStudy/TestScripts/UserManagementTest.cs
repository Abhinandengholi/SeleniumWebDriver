using CaseStudy.PageObjects;
using CaseStudy.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.TestScripts
{
        [TestFixture]
        internal class UserManagementTest : CoreCodes
        {
            //Asserts

            [Test, Order(1), Category("Regression Test")]
            public void CreateAcccountTest()
            {
            var homepage = new NaaptolHomePage(driver);
            Thread.Sleep(2000);
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "NaaptolSearch";
            List<SearchData> searchDataList = ExcelUtils.ReadSignUpData(excelFilePath, sheetName);
            foreach (var searchData in searchDataList)
            {
                string? searchText = searchData.searchText;
                string? getProduct = searchData.getProduct;

                var searchpage = homepage.TypeSearch(searchText);
                Thread.Sleep(4000);
                var productpage = searchpage.SelectProduct(getProduct);
                Thread.Sleep(5000);
                List<string> lstwindow = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(lstwindow[1]);
                Thread.Sleep(4000);
                productpage.SizecheckClick();
                Thread.Sleep(5000);
                productpage.ClickAddCart();
                string urllink = productpage.GetTitle();
                Thread.Sleep(2000);
                Assert.That(urllink, Is.EqualTo(driver.FindElement(By.XPath("//a[contains(text(),'BRG9')]")).GetAttribute("href")));
                productpage.ClickInQty();
                Thread.Sleep(5000);
                productpage.ClickRemove();
                productpage.ClickClose();
                Thread.Sleep(5000);

            }

        }
    }
}