using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumEx;


GHPTests gHPTests=new GHPTests();
Console.WriteLine("1.Edge 2.Chrome");
int ch=Convert.ToInt32(Console.ReadLine());
switch(ch)
{
    case 1:
        gHPTests.InitializeEdgeDriver(); break; 
        case 2:
        gHPTests.InitializeChromeDriver(); break;
}

try
{
    // gHPTests.Titletest();
    //gHPTests.PageSourceandURLTest();
    //gHPTests.GStest();
    //gHPTests.GmailLinkTest();
    //gHPTests.ImageLinkTest();
    gHPTests.LocalizationTest();
  
}
catch(AssertionException)
{
    Console.WriteLine("Test failed");
}

gHPTests.Destruct();