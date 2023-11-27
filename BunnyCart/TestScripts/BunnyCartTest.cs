using   BunnyCart.PageObjects;
using BunnyCart.Utilities;
using OpenQA.Selenium;
using Serilog;
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

        /*try
        {
            Assert.That(driver.FindElement(By.XPath("//h1[contains(text(),'Create an Account')]")).Text,
               Is.EqualTo("Create an Account")); ;
            //Assert.That(driver.FindElement(By.XPath("//div["+"@class= 'modal-inner-wrap']//following::h1[2]")).
            bchp.SignUp("Abhi", "Nand", "abhi04@.com", "1234", "1234", "3243434");

        }
        catch (AssertionException )
        {
            Console.WriteLine("SignUp Failed");
        }*/
        /* [Test]
         public void SignUpTest()
         {
             string currDir = Directory.GetParent(@"../../../").FullName;
             string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
             Log.Logger = new LoggerConfiguration()
                 .WriteTo.Console()
                 .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                 .CreateLogger();
             BCHomePage bchp = new(driver);
             Log.Information("Create Account Test Started");
             bchp.ClickCeateAccountLink();
             Log.Information("Create Account Link Clicked");
             Thread.Sleep(2000);
             //Assert.That(driver.FindElement(By.XPath("//h1[contains(text(),'Create an Account')]")).Text,
             // Is.EqualTo("Create an Account")); 
             try
             {
                 //Assert.That(driver?.FindElement(By.XPath("//div[" +
                 //    "@class='modal-inner-wrap']//following::h1[2]")).Text,
                 //    Is.EqualTo("Create an Account"));
                 Assert.IsTrue(driver?.FindElement(By.XPath("//div[" +
                     "@class='modal-inner-wrap']//following::h1[2]")).Text
                     == "Create anAccount", $"Test failed for Create Account");
                 Log.Information("Test passed for Create Account");

                 test = extent.CreateTest("Create Account Link Test - Pass");
                 test.Pass("Create Account Link success");
                 Console.WriteLine("ERCP");
             }
             catch(AssertionException ex)
             {
                 Log.Error($"Test failed for Create Account. \n Exception:{ex.Message}");
                 test = extent.CreateTest("Create Account Link Test - Fail");
                 test.Fail("Create Account Link failed");
                 Console.WriteLine("ERCF");
             }

             //string? currDir = Directory.GetParent(@"../../../")?.FullName;
             string? excelFilePath = currDir + "/TestData/InputData.xlsx";
             string? sheetName = "CreateAccount";

             List<SignUp> excelDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath, sheetName);

             foreach (var excelData in excelDataList)
             {

                 string? firstName = excelData?.FirstName;
                 string? lastName = excelData?.LastName;
                 string? email = excelData?.Email;
                 string? pwd = excelData?.Password;
                 string? conpwd = excelData?.ConfirmPassword;
                 string? mbno = excelData?.MobileNumber;

                 Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");


                 bchp.SignUp(firstName, lastName, email, pwd, conpwd, mbno);
                 // Assert.That(""."")

             }
             Log.CloseAndFlush();

         }*/
        [Test]
        public void SignUpTest()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            BCHomePage bchp = new(driver);
            Log.Information("Create Account Test Started");
            bchp.ClickCeateAccountLink();
            Log.Information("Create Account Link Clicked");
            Thread.Sleep(2000);
            //Assert.That(driver.FindElement(By.XPath("//h1[contains(text(),'Create an Account')]")).Text,
            // Is.EqualTo("Create an Account")); 
            try
            {
                /*Assert.That(driver?.FindElement(By.XPath("//div[" +
                    "@class='modal-inner-wrap']//following::h1[2]")).Text,
                    Is.EqualTo("Create an Account"));*/
                Assert.IsTrue(driver?.FindElement(By.XPath("//div[" +
                    "@class='modal-inner-wrap']//following::h1[2]")).Text
                    == "Create anAccount", $"Test failed for Create Account");
                LogTestResult("Create Account Link Test", "Create Account Link success");

                //Log.Information("Test passed for Create Account");
                //test = extent.CreateTest("Create Account Link Test - Pass");
                //test.Pass("Create Account Link success");
                //Console.WriteLine("ERCP");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Create Account Link Test", "Create Account Link failed", ex.Message);
                //    Log.Error($"Test failed for Create Account. \n Exception:{ex.Message}");
                //    test = extent.CreateTest("Create Account Link Test - Fail");
                //    test.Fail("Create Account Link failed");
                //    Console.WriteLine("ERCF");
            }

            //string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "CreateAccount";

            List<SignUp> excelDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {

                string? firstName = excelData?.FirstName;
                string? lastName = excelData?.LastName;
                string? email = excelData?.Email;
                string? pwd = excelData?.Password;
                string? conpwd = excelData?.ConfirmPassword;
                string? mbno = excelData?.MobileNumber;

                Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");


                bchp.SignUp(firstName, lastName, email, pwd, conpwd, mbno);
                // Assert.That(""."")

            }

            Log.CloseAndFlush();

        }
             
             
    }
}

