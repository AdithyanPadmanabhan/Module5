using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWrightNunit
{
    [TestFixture]
    internal class EATests : PageTest
    {


        [SetUp]

        public async Task SetUp()
        {
            Console.WriteLine("opened browser");
            await Page.GotoAsync("http://eaapp.somee.com/");
            Console.WriteLine("Page Loaded");
        }
        [Test]

        public async Task LoginTest()
        {
           

            await Page.GetByText("Login").ClickAsync();


/*
            var linklogin = Page.Locator(selector: "text=Login"); //another method

            await linklogin.ClickAsync();*/

            await Console.Out.WriteLineAsync("Link Clicked");
            await Expect(Page).ToHaveURLAsync("http://eaapp.somee.com/Account/Login");
           /* await Page.Locator("#UserName").FillAsync(value: "admin");
            await Page.Locator("#Password").FillAsync(value: "password");*/

            //another method

            await Page.FillAsync(selector: "#UserName", value: "admin");

            await Page.FillAsync(selector: "#Password", value: "password");

            await Console.Out.WriteLineAsync("Typed");

            //  await Page.Locator("//input[@value='Log in']").ClickAsync(); //another method


            var btnlogin = Page.Locator(selector: "input", new PageLocatorOptions //another method
            {

                HasTextString = "Log in"
            });




           /* var btnlogin = Page.Locator(selector: "text=Log in"); //another method*/

            await btnlogin.ClickAsync();

            await Console.Out.WriteLineAsync("Clicked");

           // await Expect(Page).ToHaveTitleAsync("Home - Execute Automation Employee App");

            await Expect(Page.Locator(selector:"text='Hello admin!'")).ToBeVisibleAsync();
        }
    }
}
