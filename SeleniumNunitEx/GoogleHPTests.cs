using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitEx
{
    [TestFixture]
    internal class GoogleHPTests : CoreCodes
    {
        [Ignore(" ")]
        [Test]
        [Order(10)]
        public void Titletest()
        {
            Thread.Sleep(2000);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title Test Passed");
        }

        [Test]
        [Order(20)]
        public void GStest()
        {
            string? currDir = Directory.GetParent(@"../../../").FullName;
            string? excelFilePath = currDir + "\\InputData.xlsx";
            Console.Write(excelFilePath);
            List<ExcelData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath);
            foreach (var excelData in excelDataList)
            {
                Console.WriteLine($"Text:{excelData.SearchText}");
                IWebElement Searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
                Searchinputtextbox.SendKeys(excelData.SearchText);
                Thread.Sleep(3000);
                IWebElement searchbutton = driver.FindElement(By.ClassName("gNO89b"));       //Name("btnK"));
                searchbutton.Click();
                Assert.That(driver.Title, Is.EqualTo(excelData.SearchText + " - Google Search"));
                Console.WriteLine("GS-Test passed");
                driver.Navigate().GoToUrl("https://www.google.com/");
            }
        }
            [Ignore(" ")]
            [Test]
            public void CheckAllLinksStatusTest()
            {
                List<IWebElement> allLinks = driver.FindElements(By.TagName("a")).ToList();
                foreach (var link in allLinks)
                {
                    string url = link.GetAttribute("href");
                    if (url == null)
                    {
                        Console.WriteLine("URL is null");
                        continue;
                    }
                    else
                    {
                        bool isworking = CheckLinkStatus(url);
                        if (isworking)
                        {
                            Console.WriteLine(url + "is working");
                        }
                        else
                        {
                            Console.WriteLine(url + "is not working");
                        }
                    }
                }
            }
        }
    }

