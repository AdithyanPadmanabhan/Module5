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

        [Test]

        public async Task LoginTest()
        {
            Console.WriteLine("opened browser");
            await Page.GotoAsync("http://eaapp.somee.com/");
            Console.WriteLine("Page Loaded");

            await Page.GetByText("Login").ClickAsync();

            await Console.Out.WriteLineAsync("Link Clicked");
            await Expect(Page).ToHaveURLAsync("http://eaapp.somee.com/Account/Login");
            await Page.Locator("#UserName").FillAsync(value: "admin");
            await Page.Locator("#Password").FillAsync(value: "password");
            await Console.Out.WriteLineAsync("Typed");

            //  await Page.Locator("//input[@value='Log in']").ClickAsync();
            var btnLogin = Page.Locator(selector: "input", new PageLocatorOptions
            {

                HasTextString ="Log in"
            });

            await btnLogin.ClickAsync();

            await Console.Out.WriteLineAsync("Clicked");

            await Expect(Page).ToHaveTitleAsync("Home - Execute Automation Employee App");

        }
    }
}
