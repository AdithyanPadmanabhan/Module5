using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlayWrightNunit
{
    public class GoogleHomePageTests : PageTest
    {
        [SetUp]
        public void Setup()
        {
        }

       /*  [Test]// manual instances
         public async Task Test1()
         {
             using var playwright = await Playwright.CreateAsync();

             //Launch browser
             await using var browser = await playwright.Chromium.LaunchAsync(
                 
                 new BrowserTypeLaunchOptions
                 {
                     Headless = false
                 });


             //Page instance
             var context = await browser.NewContextAsync();
             var page = await context.NewPageAsync();

             Console.WriteLine("Opened Browser");
             await page.GotoAsync("https://www.google.com");

             Console.WriteLine("Page Loaded");


             string title = await page.TitleAsync();
             Console.WriteLine(title);

             //await page.GetByTitle("Search").FillAsync("hp laptop");
             await page.Locator("#APjFqb").FillAsync("selenium");


             Console.WriteLine("Typed");

             await page.Locator("(//input[@value='Google Search'])[2]").ClickAsync();
             Console.WriteLine("clicked");

         }*/
        [Test] //Play wright managed instances
         public async Task Test2()
         {


             Console.WriteLine("Opened Browser");
             await Page.GotoAsync("https://www.google.com");

             Console.WriteLine("Page Loaded");


             string title = await Page.TitleAsync();
             Console.WriteLine(title);

             //await page.GetByTitle("Search").FillAsync("hp laptop");
             await Page.Locator("#APjFqb").FillAsync("selenium");


             Console.WriteLine("Typed");

             await Page.Locator("(//input[@value='Google Search'])[2]").ClickAsync();
            //Console.WriteLine("clicked");
            //title = await Page.TitleAsync();
            // Assert.That(title,Does.Contain("selenium"));
            await Expect(Page).ToHaveTitleAsync("selenium - Google Search");
         } 
    }
}