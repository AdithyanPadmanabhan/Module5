﻿






using Microsoft.Playwright;
//playright startup
using var playwright = await Playwright.CreateAsync();

//Launch browser
await using var browser = await playwright.Chromium.LaunchAsync();


//Page instance
var context =await browser.NewContextAsync();
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
