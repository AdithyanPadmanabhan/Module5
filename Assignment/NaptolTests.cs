using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    [TestFixture]
    internal class NaptolTests :PageTest
    {
        [SetUp]

       

        public async Task SetUp()
        {
            Console.WriteLine("opened browser");
            await Page.GotoAsync("https://www.naaptol.com/");
            Console.WriteLine("Page Loaded");
        }
        [Test]

        public async Task ProductTest()
        {

            await Page.FillAsync(selector: "#header_search_text", value: "eyewear");
            await Console.Out.WriteLineAsync("typed");

            await Page.Locator("(//div[@class='search'])[2]").ClickAsync();
            await Console.Out.WriteLineAsync("searched");

        }
        }
}
