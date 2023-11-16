using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitEx
{
    internal class CoreCodes
    {
        Dictionary<string, string>? properties;
        IWebDriver driver;
        public void ReadConfigSettings() 
        {
            string currDir = Directory.GetParent(@"../../../").FullName;//getting the current directory
            properties = new Dictionary<string, string>();//declaring  the dictionary
            string filename = currDir + "/config/config.properties";//taking the file from wworking directory
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
            foreach(var prop in properties)
            {
                if (properties["browser"].ToLower()=="chrome")
                {
                    driver = new ChromeDriver();
                }
            }
        }
        [OneTimeTearDown]   
        public void Cleanup()
        {

        }
    }
}