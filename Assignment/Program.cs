using Assignment;
using NUnit.Framework;

//14/11/2023

AmazonHP ahp = new();
try
{
    ahp.InitializeChromeDriver();
    ahp.Titletest();
    ahp.OrganizTest();
   
}
catch(AssertionException)
{
    Console.WriteLine("Test failed");
}
ahp.Destruct();