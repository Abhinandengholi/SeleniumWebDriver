using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Page;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart
{
    internal class CoreCodes
    {
        Dictionary<string, string>? properties;
       public  IWebDriver driver;
        public void ReadConfigSettings() 
        {
            string currDir = Directory.GetParent(@"../../../").FullName;//getting the current directory
            properties = new Dictionary<string, string>();//declaring  the dictionary
            string filename = currDir + "/ConfigSettings/config.properties";//taking the file from wworking directory
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)//for getting file data even if there are whitespace
            {
                if(!string.IsNullOrWhiteSpace(line)&& line.Contains("="))
                {
                    string[] parts=line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }
        }
        [OneTimeSetUp]
        public void InitializeBrowser()
        {
            ReadConfigSettings();
                if (properties["browser"].ToLower()=="chrome")
                {
                    driver = new ChromeDriver();
                }
                else if (properties["browser"].ToLower() == "edge")
                {
                    driver = new EdgeDriver();
                }
                driver.Url = properties["baseUrl"];
                driver.Manage().Window.Maximize();
        }
        
        public bool CheckLinkStatus(string url)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)
                    System.Net.WebRequest.Create(url);
                request.Method = "HEAD";
                using (var response =request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;   
            }
        }
        [OneTimeTearDown]   
        public void Cleanup()
        {
            driver.Quit();  
        }
        public void TakeScreenshot()
        {
            ITakesScreenshot its = (ITakesScreenshot)driver;
            Screenshot screenshot = its.GetScreenshot();
            string currDir = Directory.GetParent(@"../../../").FullName;
            string filepath = currDir + "/Screenshot/ss_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            screenshot.SaveAsFile(filepath);
            Console.WriteLine("Taken ss");
        }
    }
}