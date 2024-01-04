using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlayWrightPOM.PWTests.Pages;
using PlayWrightPOM.Test_Data_Classes;
using PlayWrightPOM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWrightPOM.PWTests.Tests
{
    [TestFixture]
    public class LoginPageTests : PageTest
    {
        Dictionary<string, string> ?Properties;
        string? currentDirectory;
        public void ReadConfigSettings()

        {
            string? currentDirectory = Directory.GetParent(@"../../../")?.FullName;

          

            Properties = new Dictionary<string, string>();
            string fileName = currentDirectory + "/ConfigSettings/config.properties";
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains('='))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    Properties[key] = value;
                }
            }

        }
        [SetUp]
        public async Task Setup()
        {
            ReadConfigSettings();
            Console.WriteLine("opened browser");



            await Page.GotoAsync(Properties["baseUrl"]);
              
            Console.WriteLine("Page Loaded");
           
        }

        [Test]
      
        public async Task LoginTest()
        {
            NewLoginPage loginPage = new (Page);
            string? excelFilePath = currentDirectory + "/Test Data/EAData.xlsx";
            string? sheetName = "Login Data";

            List<EAText> excelDataList = DataRead.ReadLoginCredentialData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? username = excelData.UserName;
                string? password = excelData.Password;


                await loginPage.ClickLoginLink();
                await loginPage.Login(username, password);

                await Page.ScreenshotAsync(new()
                {
                    Path = currentDirectory + "/Screenshots/ss_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".png",
            });
                Assert.IsTrue(await loginPage.CheckWelcomeMssage());


            }
        }


    }
}
